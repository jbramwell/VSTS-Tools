using CommandLineParser.Arguments;
using VSTSShared;

namespace VSTSKeep
{
    public class CommandLineArgs : CommandLineArgsBase
    {
        [ValueArgument(typeof(string), 't', "project", Description = "Specifies the name of the VSTS team project", Optional = false)]
        public string Project;

        [ValueArgument(typeof(string), 'b', "build", Description = "Specifies the build number of the build to set retention on", Optional = false)]
        public string BuildNumber;

        [ValueArgument(typeof(int), 'k', "keep", Description = "Set to 1 to keep build forever; else, set to 0")]
        public int KeepForever;

    }
}