# VSTS-Tools
Provided primarily as a set of examples for calling various REST APIs within Visual Studio Team Services (VSTS), VSTS-Tools  is a collection of 
command-line utilities for interacting with VSTS.

The current set of tools/examples, include:

## VSTS-Keep
Allows you to set the retention for a specific build to "Keep Forever" or you can also remove the "Keep Forever" flag so the build will follow The
existing retention rules as configured for your VSTS project.

## VSTS-Get
Allows you to download a single file or an entire folder from a Git-based repo in VSTS without the need for a Git client.

**NOTE**: TFVC-based repositories are not yet supported by these tools.
