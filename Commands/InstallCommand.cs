namespace Shitman
{
    public class InstallCommand
    {
        public async Task Run(string package)
        {
            var pkg = await Shitman.aurClient.GetPackage(package);

            if(pkg == null)
            {
                Console.WriteLine($"Package {package} not found!");
                return;
            }

            Console.WriteLine($"Package {pkg.Name} Version {pkg.Version} is now installing...");

            string repoDir = Path.Combine(Shitman.cacheDir, package);

            if (Directory.Exists(repoDir))
            {
                ProcessRunner.RunInDir(repoDir, "git", "pull");
            }
            else
            {
                Console.WriteLine($"Cloning repository...");
                ProcessRunner.Run("git", $"clone https://aur.archlinux.org/{package}.git {repoDir}");
            }

            Console.WriteLine($"Makepkg...");
            ProcessRunner.RunInDir(repoDir, "makepkg", "-si --skippgpcheck --noconfirm");

            Console.WriteLine($"Package {package} was installed successfully!");
        }
    }
}