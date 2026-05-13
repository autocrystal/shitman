namespace Shitman
{
    public class SearchCommand
    {
        public async Task Run(string query)
        {
            Shitman.logger.Info($"Searching for program: {query}");

            var packages = await Shitman.aurClient.Search(query);
            
            foreach (var pkg in packages) {
                Shitman.logger.Info(pkg.Name);
            }
        }
    }
}