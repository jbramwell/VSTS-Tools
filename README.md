# VSTS-Tools
Provided primarily as a set of examples for calling various REST APIs within Visual Studio Team Services (VSTS), VSTS-Tools  is a collection of 
command-line utilities for interacting with VSTS.

The current set of tools/examples, include:

## VSTS-Keep
Allows you to set the retention for a specific build to "Keep Forever" or you can also remove the "Keep Forever" flag so the build will follow The
existing retention rules as configured for your VSTS project. The build to be modified is designated by passing in the Build Number (not the Build
ID). The Build Number is mapped to the Build ID internally and the retention is set accordingly.

### Usage
There are multiple command-line arguments for calling VSTS-Keep, including:

|Name     |Required|Comments                                                                        |
|---------|--------|--------------------------------------------------------------------------------|
|-a       |Yes     |Specifies the VSTS account to use.                                              |
|-t       |Yes     |Specifies the name of the VSTS team project containing the build to be modified.|
|-u       |No      |Specifies the User ID used to sign into VSTS (optional if using a PAT).         |
|-p       |Yes     |Specifies the password or Personal Access Token (PAT) used to sign into VSTS.   |
|-b       |Yes     |Specifies the build number to set retention on/off for.                         |
|-k       |No      |If specified, sets to "Keep Forever"; Otherwise, removes the flag.              |
|-v       |No      |If specified, turns on verbose output.                                          |

**Examples**

Set retention to "Keep Forever" while authenticating with Alternate (Basic) Credentals:

    VSTS-Keep -a MyAccount -t MyProject -u someone@hotmail.com -p MyS3cr3tP@ssw0rd -b 20160303.1 -k

Set retention to "Keep Forever" while authenticating with a Personal Access Token (PAT):

    VSTS-Keep -a MyAccount -t MyProject -p aq4atoiecgzpt7gtw54dlzfja7vlr3hbkm2kl2pkjmr32obr5juq -b 20160303.1 -k

Remove retention while authenticating with a Personal Access Token (PAT):

    VSTS-Keep -a MyAccount -t MyProject -p aq4atoiecgzpt7gtw54dlzfja7vlr3hbkm2kl2pkjmr32obr5juq -b 20160303.1

## VSTS-Get
Allows you to download a single file or an entire folder from a Git-based repo in VSTS without the need for a Git client.

**NOTE**: TFVC-based repositories are not yet supported by these tools.
