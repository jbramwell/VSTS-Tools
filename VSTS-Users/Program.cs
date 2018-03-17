using CommandLineParser.Arguments;
using System;
using System.Diagnostics;
using VSTSShared.BaseClasses;

namespace VSTSUsers
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

                parser.ShowUsageHeader = "Retrieves a list of user e-mail addresses, last access date/time and license type " +
                    "from VSTS in comma-delimited format.\r\n\r\n" +
                    "VSTS-Users -a <Account> [-u <User ID>] -p <Password> ";
                parser.ShowUsageOnEmptyCommandline = true;

                parser.ExtractArgumentAttributes(cmdLineArgs);
                parser.ParseCommandLine(args);

                if (parser.ParsingSucceeded)
                {
                    var authentication = new BasicAuthentication(cmdLineArgs.Account, cmdLineArgs.UserId, cmdLineArgs.Password);
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