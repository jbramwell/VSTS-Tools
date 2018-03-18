using System;
using System.Diagnostics;
using System.Linq;
using VSTSShared.BaseClasses;
using VSTSShared.Helpers;

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
                parser.ShowUsageHeader = "Retrieves a list of user e-mail addresses, last access date/time and license type " +
                    "from VSTS in comma-delimited format.\r\n\r\n" +
                    "VSTS-Users -a <Account> [-u <User ID>] -p <Password> ";
                parser.ShowUsageOnEmptyCommandline = true;

                parser.ExtractArgumentAttributes(cmdLineArgs);
                parser.ParseCommandLine(args);

                if (parser.ParsingSucceeded)
                {
                    var authentication = new BasicAuthentication(cmdLineArgs.Account, cmdLineArgs.UserId, cmdLineArgs.Password);
                    var helper = new VstsHelper();

                    var results = helper.GetVstsUsers(authentication);

                    if (results != null)
                    {
                        if (cmdLineArgs.IncludeHeader)
                        {
                            Console.WriteLine($"{QuoteIfHasSpaces("User", cmdLineArgs.IncludeQuotes)}," +
                                              $"{QuoteIfHasSpaces("Last Accessed Date/Time", cmdLineArgs.IncludeQuotes)}," +
                                              QuoteIfHasSpaces("User License", cmdLineArgs.IncludeQuotes));
                        }

                        foreach (var user in results.Value.OrderBy(x => x.User.MailAddress))
                        {
                            var email = QuoteIfHasSpaces(user.User.MailAddress, cmdLineArgs.IncludeQuotes);
                            var lastAccess = QuoteIfHasSpaces(user.LastAccessedDate.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss"), cmdLineArgs.IncludeQuotes);
                            var userLicense = QuoteIfHasSpaces(user.AccessLevel.LicenseDisplayName, cmdLineArgs.IncludeQuotes);

                            Console.WriteLine($"{email},{lastAccess},{userLicense}");
                        }
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

        /// <summary>
        /// Optionally add quotes around some text if the text has embedded spaces.
        /// </summary>
        /// <param name="text">The text to quote.</param>
        /// <param name="includeQuotes">If <c>true</c>, then text containing spaces will be quoted;
        /// Otherwise, the text will not be quoted.</param>
        /// <returns></returns>
        private static string QuoteIfHasSpaces(string text, bool includeQuotes)
        {
            if (includeQuotes)
            {
                return (text.IndexOf(' ') >= 0) ? $"\"{text}\"" : text;
            }

            return text;
        }
    }
}