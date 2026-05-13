namespace Shitman
{
    public class FetchCommand
    {
        public async Task Run(string name)
        {
            var pkg = await Shitman.aurClient.GetPackage(name);

            if (pkg == null)
            {
                Shitman.logger.Error($"Could not find package: {name}");
                return;
            }

            Shitman.logger.Info($"## {pkg.Name} {pkg.Version}");
            PrintField("Description", pkg.Description);
            PrintField("Project URL", pkg.URL);
            PrintField("AUR Link", $"https://aur.archlinux.org{pkg.URLPath}");
            PrintField("License", string.Join(", ", pkg.License ?? new List<string> { "None" }));

            PrintField("Maintainer", pkg.Maintainer ?? "Orphaned");
            PrintField("Votes", pkg.NumVotes.ToString());
            PrintField("Popularity", pkg.Popularity.ToString("F2"));
            
            if (pkg.OutOfDate.HasValue)
            {
                Shitman.logger.Warn($"Status      : Out of Date (Flagged on {DateTimeOffset.FromUnixTimeSeconds(pkg.OutOfDate.Value).Date:yyyy-MM-dd})");
            }

            Console.WriteLine();
            PrintList("Depends On", pkg.Depends);
            PrintList("Make Deps", pkg.MakeDepends);
            PrintList("Opt Deps", pkg.OptDepends);
            PrintList("Check Deps", pkg.CheckDepends);

            PrintList("Conflicts", pkg.Conflicts);
            PrintList("Provides", pkg.Provides);
        }

        private void PrintField(string label, string value)
        {
            if (string.IsNullOrEmpty(value)) return;
            Shitman.logger.Info($"{label,-15}: {value}");
        }

        private void PrintList(string label, List<string>? items)
        {
            if (items == null || items.Count == 0) return;
            Shitman.logger.Info($"{label,-15}: {string.Join("  ", items)}");
        }
    }
}