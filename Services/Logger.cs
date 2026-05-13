namespace Shitman
{
    public class Logger
    {
        private const string Prefix = "[shitman]";

        public void Info(string message) => WriteLog("info", message, ConsoleColor.Cyan);
        public void Warn(string message) => WriteLog("warn", message, ConsoleColor.Yellow);
        public void Error(string message) => WriteLog("error", message, ConsoleColor.Red);

        private void WriteLog(string level, string message, ConsoleColor levelColor)
        {
            Console.Write($"\u001b[38;2;101;67;33m{Prefix} \u001b[0m");

            Console.ForegroundColor = levelColor;
            Console.Write($"[{level}] ");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);

            Console.ResetColor();
        }
    }
}