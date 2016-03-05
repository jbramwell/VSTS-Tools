using CommandLineParser.Arguments;
using System;
using System.Diagnostics;
using VSTSShared.BaseClasses;
using VSTSShared.Helpers;

namespace VSTSGet
{
    class Program
    {
        static void Main(string[] args)
        {
            // Setup parser and extract command line arguments
            var parser = new CommandLineParser.CommandLineParser();
            var cmdLineArgs = new CommandLineArgs();

            try
            {
                // Add the verbose switch programmatically because I am having issues with the attributes
                var verbose = new SwitchArgument('v', "verbose", "Turns on verbose output.", false);
                parser.Arguments.Add(verbose);

                parser.ShowUsageHeader = "Downloads a file or folder from VSTS to the specified location.\r\n\r\n" +
                    "VSTS-GET -a <Account> [-u <User ID>] -p <Password> -t <Project> -r <Repo> [-f|-o] <File/Folder> " +
                    "-d <Destination>";
                parser.ShowUsageOnEmptyCommandline = true;

                parser.ExtractArgumentAttributes(cmdLineArgs);
                parser.ParseCommandLine(args);

                if (parser.ParsingSucceeded)
                {

                    var authentication = new BasicAuthentication(cmdLineArgs.Account, cmdLineArgs.UserId, cmdLineArgs.Password);

                    if (!string.IsNullOrEmpty(cmdLineArgs.FilePath))
                    {
                        // If the --file argument was specified, then assume we're downloading a single file
                        var helper = new VstsHelper();

                        Console.WriteLine(helper.DownloadFile(authentication, cmdLineArgs.Project, cmdLineArgs.Repo,
                            cmdLineArgs.FilePath, cmdLineArgs.Destination,
                            verbose.Value)
                            ? "    File download successful."
                            : "    File download failed.");
                    }
                    else if (!string.IsNullOrEmpty(cmdLineArgs.FolderPath))
                    {
                        var helper = new VstsHelper();

                        Console.WriteLine(helper.DownloadFolder(authentication, cmdLineArgs.Project, cmdLineArgs.Repo,
                            cmdLineArgs.FolderPath, cmdLineArgs.Destination,
                            verbose.Value)
                            ? "    Folder download successful."
                            : "    Folder download failed.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                parser.ShowUsage();
            }

            if (Debugger.IsAttached)
            {
                // Keep the console window from closing when running from IDE
                Console.WriteLine("\r\nPress any key to close command window.");
                Console.ReadKey();
            }
        }
    }
}