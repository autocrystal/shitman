namespace Shitman
{
    public class FetchCommand
    {
        public async Task Run(string name)
        {
            var pkg = await Shitman.aurClient.GetPackage(name);
            
            Console.WriteLine($"// info about package: {pkg.Name}");
            Console.WriteLine($"name: {pkg.Name}, version: {pkg.Version}, description: ${pkg.Description}, id: ${pkg.ID}");

            return;
        }
    }
}