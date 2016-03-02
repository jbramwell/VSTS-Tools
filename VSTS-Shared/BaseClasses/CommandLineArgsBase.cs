using CommandLineParser.Arguments;

namespace VSTSShared
{
    public abstract class CommandLineArgsBase
    {
        [ValueArgument(typeof(string), 'a', "account", Description = "Specifies the VSTS account to use", Optional = false)]
        public string Account;

        [ValueArgument(typeof(string), 'u', "userid", Description = "Specifies the User ID used to sign into VSTS (optional if using a PAT)")]
        public string UserId;

        [ValueArgument(typeof(string), 'p', "password", Description = "Specifies the password or Personal Access Token (PAT) used to sign into VSTS", Optional = false)]
        public string Password;

        // SwitchArgument attribute not working as expected so adding verbose programmatically
        //[ValueArgument(typeof(string), 'v', "verbose", DefaultValue = "", Description = "Set to 'on' (no quotes) to turn on verbose output.")]
        //public string Verbose;
    }
}