using CommandLineParser.Arguments;
using CommandLineParser.Validation;
using VSTSShared;

namespace VSTSGet
{
    // Either the --file or the --folder argument must be used, but not both
    [ArgumentGroupCertification("f,o", EArgumentGroupCondition.ExactlyOneUsed)]
    public class CommandLineArgs : CommandLineArgsBase
    {
        [ValueArgument(typeof(string), 't', "project", Description = "Specifies the name of the VSTS team project", Optional = false)]
        public string Project;

        [ValueArgument(typeof(string), 'r', "repo", Description = "Specifies the name of the Git repo in VSTS containing the file/folder to download", Optional = false)]
        public string Repo;

        [ValueArgument(typeof(string), 'f', "file", Description = "Specifies the file in VSTS to download")]
        public string FilePath;

        [ValueArgument(typeof(string), 'o', "folder", Description = "Specifies the folder in VSTS to download")]
        public string FolderPath;

        [ValueArgument(typeof(string), 'd', "Destination", Description = "Specifies the directory for the downloaded file(s)", Optional = false)]
        public string Destination;

    }
}