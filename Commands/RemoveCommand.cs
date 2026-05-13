namespace Shitman
{
    public class RemoveCommand
    {
        public async Task Run(string package)
        {
            Console.WriteLine($"Removing program: {package}");

            int exitCode = ProcessRunner.Run("sudo",$"pacman -Rns {package} --noconfirm");

            if (exitCode == 0)
            {
                Console.WriteLine($"Successfully removed {package}.");
                return;
            }
            else
            {
                Console.WriteLine($"Failed to remove {package}.");
                return;
            }
        }
    }
}