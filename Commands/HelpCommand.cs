namespace Shitman
{
    public class HelpCommand
    {
        public Task Run(string arg = null)
        {
            Shitman.logger.Info("Shitman - A terrible AUR helper");
            Shitman.logger.Info("-s <package>  Install a package");
            Shitman.logger.Info("-q <query>    Search for packages");
            Shitman.logger.Info("-f <package>  Fetch a package");
            Shitman.logger.Info("-r <package>  Remove a package");
            Shitman.logger.Info("-u [package]  Upgrade all or a specific package");
            Shitman.logger.Info("-l            List installed packages");
            Shitman.logger.Info("-h            Show this help message");
            return Task.CompletedTask;
        }
    }
}