namespace Shitman
{
    public class SearchCommand
    {
        public async Task Run(string query)
        {
            Console.WriteLine($"Searching for program: {query}");

            var packages = await Shitman.aurClient.Search(query);
            
            foreach (var pkg in packages) {
                Console.WriteLine(pkg.Name);
            }
        }
    }
}