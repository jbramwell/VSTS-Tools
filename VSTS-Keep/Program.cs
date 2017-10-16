using CommandLineParser.Arguments;
using System;
using System.Diagnostics;
using VSTSShared.BaseClasses;
using VSTSShared.Helpers;

namespace VSTSKeep
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
                var keepForever = new SwitchArgument('k', "keep",
                    "If specified, sets to \"Keep Forever\"; Otherwise, removes the flag.", false);

                parser.Arguments.Add(verbose);
                parser.Arguments.Add(keepForever);

                parser.ShowUsageHeader =
                    "Sets or removes \"keep forever\" retention for the specified build number in VSTS.\r\n\r\n" +
                    "VSTS-KEEP -a <Account> [-u <User ID>] -p <Password> -t <Project> -b <BuildNumber> [-k]";
                parser.ShowUsageOnEmptyCommandline = true;

                parser.ExtractArgumentAttributes(cmdLineArgs);
                parser.ParseCommandLine(args);

                if (parser.ParsingSucceeded)
                {
                    var authentication =
                        new BasicAuthentication(cmdLineArgs.Account, cmdLineArgs.UserId, cmdLineArgs.Password);
                    var helper = new VstsHelper();

                    Console.WriteLine(helper.KeepForever(authentication, cmdLineArgs.Project, cmdLineArgs.BuildNumber,
                        keepForever.Value, verbose.Value)
                        ? "    Retention set successfully."
                        : "    Failed to set retention.");
                }
            }
            catch (System.Net.WebException ex)
            {
                Console.WriteLine(ex.Message);
                if (ex.Message.Contains("(401) Unauthorized."))
                {
                    Console.WriteLine("VSTS-Keep requires access to the account's OAuth token in order to correctly set the keep forever config.");
                    Console.WriteLine("Please go to this build definition's options tab and enable build scripts to access the OAuth token.");
                }
                parser.ShowUsage();
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
