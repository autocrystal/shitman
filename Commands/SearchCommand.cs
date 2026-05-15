namespace Shitman
{
    public class SearchCommand
    {
        public async Task Run(string query)
        {
            Shitman.logger.Info($"Searching for query: {query}...");

            var packages = await Shitman.aurClient.Search(query);
            
            if(packages == null || packages.Count == 0)
            {
                Shitman.logger.Error($"Package '{query}' wasn't found!");
                return;
            }

            foreach (var pkg in packages) {
                Shitman.logger.Info($"{pkg.Name} {pkg.Version} - {pkg.Description}");
            }
        }
    }
}