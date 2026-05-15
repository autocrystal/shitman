namespace Shitman
{
    public class ListCommand
    {
        public async Task Run()
        {
            Shitman.logger.Info($"Installed AUR packages:");

            int exitCode = ProcessRunner.Run("sudo",$"pacman -Qm");

            if (exitCode == 0)
            {
                return;
            }
            else
            {
                Shitman.logger.Error($"No AUR packages found!");
                return;
            }
        }
    }
}