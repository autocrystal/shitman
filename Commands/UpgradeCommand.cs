namespace Shitman
{
    public class UpgradeCommand
    {
        public async Task Run(string name = null)
        {     
            var output = "";
            int exitCode = ProcessRunner.RunWithOutput("pacman", "-Qm", out output, false);
            if (exitCode != 0)
            {
                Shitman.logger.Error("No AUR packages found!");
                return;
            }

            if(name == null)
            {    
                var packages = output
                    .Split('\n', StringSplitOptions.RemoveEmptyEntries)
                    .Select(line => line.Split(' ')[0])
                    .ToList();

                Shitman.logger.Info($"Found {packages.Count} AUR packages, checking for updates...");

                var processed = new HashSet<string>();
                var installCommand = new InstallCommand();

                foreach (var pkg in packages)
                {
                    await installCommand.Install(pkg, processed, upgrade: true);
                }
            } else {
                var package = output
                    .Split('\n', StringSplitOptions.RemoveEmptyEntries)
                    .Select(line => line.Split(' ')[0])
                    .FirstOrDefault(pkg => pkg == name);
                
                if(package == null)
                {
                    Shitman.logger.Error($"AUR package '{name}' not found!");
                    return;
                } 

                Shitman.logger.Info($"AUR package '{name}' found, upgrading...");

                var processed = new HashSet<string>();
                var installCommand = new InstallCommand();

                await installCommand.Install(package, processed, upgrade: true);
            }

            Shitman.logger.Info("Upgrade complete!");
        }
    }
}