using System;
using System.Threading.Tasks;

namespace Shitman
{
    class Shitman
    {
        public static AurClient aurClient = new AurClient();
        public static Logger logger = new Logger();
        public static string cacheDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),".cache/shitman/repos");

        static async Task Main(string[] args)
        {
            aurClient.Init();

            SearchCommand searchCommand = new SearchCommand();
            RemoveCommand removeCommand = new RemoveCommand();
            InstallCommand installCommand = new InstallCommand();
            FetchCommand fetchCommand = new FetchCommand();
            ListCommand listCommand = new ListCommand();
            UpgradeCommand upgradeCommand = new UpgradeCommand();

            if (args.Length == 0)
            {
                logger.Error("No command provided, exiting...");
                return;
            }

            string command = args[0].ToLower();

            switch (command)
            {
                case "-s":
                    if (args.Length != 2)
                    {
                        logger.Error("Install requires a package name!");
                        return;
                    }

                    await installCommand.Run(args[1]);
                    break;

                case "-q":
                    if (args.Length < 2)
                    {
                        logger.Error("Search requires a query!");
                        return;
                    }

                    string query = string.Join(" ", args, 1, args.Length - 1);

                    await searchCommand.Run(query);
                    break;

                case "-f":
                    if (args.Length != 2)
                    {
                        logger.Error("Fetch requires a package name!");
                        return;
                    }

                    await fetchCommand.Run(args[1]);
                    break;  

                case "-r":
                    if (args.Length != 2)
                    {
                        logger.Error("Remove requires a package name!");
                        return;
                    }

                    await removeCommand.Run(args[1]);
                    break;
                case "-u":
                    string name = args.Length == 2 ? args[1] : null;
                    await upgradeCommand.Run(name);
                    break;      

                case "-l":
                    await listCommand.Run();
                    break;     

                default:
                    logger.Error("Invalid command.");
                    break;
            }
        }
    }
}