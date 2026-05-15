namespace Shitman
{
    public class RemoveCommand
    {
        public async Task Run(string package)
        {
            Shitman.logger.Info($"Removing package: {package}");

            int exitCode = ProcessRunner.Run("sudo",$"pacman -Rns {package} --noconfirm");

            if (exitCode == 0)
            {
                Shitman.logger.Info($"Successfully removed {package}.");
                return;
            }
            else
            {
                Shitman.logger.Error($"Failed to remove {package}.");
                return;
            }
        }
    }
}