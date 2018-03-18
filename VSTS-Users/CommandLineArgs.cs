using CommandLineParser.Arguments;
using VSTSShared;

namespace VSTSUsers
{
    public class CommandLineArgs : CommandLineArgsBase
    {
        [SwitchArgument('q', "quote", false, Description = "Adds quotation marks to any items that include spaces.", Optional = true)]
        public bool IncludeQuotes;

        [SwitchArgument('h', "header", false, Description = "Include a header line in the output.", Optional = true)]
        public bool IncludeHeader;
    }
}