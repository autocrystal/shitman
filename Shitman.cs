using System;
using System.Threading.Tasks;

namespace Shitman
{
    class Shitman
    {
        public static AurClient aurClient = new AurClient();
        public static Logger logger = new Logger();
        public static string cacheDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".cache/shitman/repos");

        static async Task Main(string[] args)
        {
            aurClient.Init();

            if (args.Length == 0)
            {
                logger.Error("No command provided, exiting...");
                return;
            }

            string command = args[0].ToLower();

            switch (command)
            {
                case "-s":
                    if (args.Length != 2) { logger.Error("Install requires a package name!"); return; }
                    await new InstallCommand().Run(args[1]);
                    break;

                case "-q":
                    if (args.Length < 2) { logger.Error("Search requires a query!"); return; }
                    await new SearchCommand().Run(string.Join(" ", args, 1, args.Length - 1));
                    break;

                case "-f":
                    if (args.Length != 2) { logger.Error("Fetch requires a package name!"); return; }
                    await new FetchCommand().Run(args[1]);
                    break;

                case "-r":
                    if (args.Length != 2) { logger.Error("Remove requires a package name!"); return; }
                    await new RemoveCommand().Run(args[1]);
                    break;

                case "-u":
                    await new UpgradeCommand().Run(args.Length == 2 ? args[1] : null);
                    break;

                case "-l":
                    await new ListCommand().Run();
                    break;

                case "-h":
                    await new HelpCommand().Run();
                    break;

                default:
                    logger.Error("Invalid command. Use -h for help.");
                    break;
            }
        }
    }
}