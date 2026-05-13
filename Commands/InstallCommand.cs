namespace Shitman
{
    public class InstallCommand
    {
        public async Task Run(string package)
        {
            var processed = new HashSet<string>();
            await Install(package, processed);
            Shitman.logger.Info($"Installation of {package} complete!");
        }

        public async Task Install(string _name, HashSet<string> processed)
        {
            string name = _name.Split(new[] { '>', '<', '=', ' ' }, StringSplitOptions.RemoveEmptyEntries)[0];

            if (processed.Contains(name)) return;
            processed.Add(name);

            if (IsInstalled(name))
            {
                Shitman.logger.Warn($"{name} is already installed, skipping...");
                return;
            }

            if (IsRepo(name))
            {
                Shitman.logger.Warn($"{name} in official repos, using pacman...");
                ProcessRunner.Run("sudo", $"pacman -S {name} --noconfirm --needed");
                return;
            }

            var pkg = await Shitman.aurClient.GetPackage(name);

            if (pkg == null)
            {
                Shitman.logger.Error($"Package {name} not found in AUR or Repos!");
                return;
            }

            if (pkg.Depends != null || pkg.MakeDepends != null)
            {
                var allDeps = (pkg.Depends ?? new List<string>())
                              .Concat(pkg.MakeDepends ?? new List<string>());

                foreach (var dep in allDeps)
                {
                    await Install(dep, processed);
                }
            }

            Shitman.logger.Info($"Building {pkg.Name} from AUR...");
            await Build(pkg);
        }

        private async Task Build(AurPackage pkg)
        {
            string repoDir = Path.Combine(Shitman.cacheDir, pkg.Name);

            if (Directory.Exists(repoDir))
            {
                ProcessRunner.RunInDir(repoDir, "git", "pull");
            }
            else
            {
                ProcessRunner.Run("git", $"clone https://aur.archlinux.org/{pkg.Name}.git {repoDir}");
            }

            ProcessRunner.RunInDir(repoDir, "makepkg", "-si --skippgpcheck --noconfirm");
        }

        private bool IsInstalled(string name) => 
            ProcessRunner.Run("pacman", $"-Qi {name}", false) == 0;

        private bool IsRepo(string name) => 
            ProcessRunner.Run("pacman", $"-Si {name}", false) == 0;
    }
}