using System;
using System.Diagnostics;

namespace Shitman
{
    public static class ProcessRunner
    {

        public static int Run(string command, string arguments, bool verbose = true)
        {
            return RunInternal(null, command, arguments, verbose);
        }

        public static int RunInDir(string workingDir, string command, string arguments, bool verbose = true)
        {
            return RunInternal(workingDir, command, arguments, verbose);
        }


        private static int RunInternal(string? workingDir, string command, string arguments, bool verbose)
        {
            Process process = new Process();

            process.StartInfo.FileName = command;
            process.StartInfo.Arguments = arguments;

            process.StartInfo.WorkingDirectory = workingDir ?? Environment.CurrentDirectory;

            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.UseShellExecute = false;

            process.OutputDataReceived += (_, e) =>
            {
                if (verbose && !string.IsNullOrEmpty(e.Data))
                    Console.WriteLine(e.Data);
            };

            process.ErrorDataReceived += (_, e) =>
            {
                if (verbose && !string.IsNullOrEmpty(e.Data))
                    Console.WriteLine(e.Data);
            };

            process.Start();

            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            process.WaitForExit();

            return process.ExitCode;
        }
    }
}