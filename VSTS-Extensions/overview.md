# VSTS-Tools
This extension provides several build tasks to help you diagnose your builds as well as control the retention of completed builds. The initial release has some limitations so see the Road Map outlined below to get an idea of what's coming next for this set of extensions.

# Extensions

### VSTS-List Files
This extension will list out (in the log) all files beneath the folder specified as the *Root Folder*. There are two parameters that can be set with this task:

* Root Directory - all files and folders beneath the root directory will be listed (recursively).
* Execute on Debug Only - if checked, the task will execute only if **system.debug** is set to **true**.

![VSTS-List Files Image](https://github.com/jbramwell/VSTS-Tools/blob/master/VSTS-Extensions/screenshots/ListFiles.png?raw=true)

## VSTS-List Variables
This extension will list out (in the log) all variables that are defined at the time this extension is executed. There is one parameter that can be set with this task:

* Execute on Debug Only - if checked, the task will execute only if **system.debug** is set to **true**.

![VSTS-List Variables Image](https://github.com/jbramwell/VSTS-Tools/blob/master/VSTS-Extensions/screenshots/ListVariables.png?raw=true)

## VSTS-Keep
*Coming Soon!* This extension allows you to set the retention for a specific build to *Keep Forever*.

# Road Map
|Release|Description                                |
|-------|-------------------------------------------|
| 1.0.0 | Initial release.                          |
| 2.0.0 | VSTS-Keep task added.                |
| 2.1.0 | Node support (currently PowerShell only). |
| x.y.z | TBD... (based on requests)                |

# Contact Us
* [Follow us on Twitter](https://twitter.com/moonspacelabs)
* [File an issue on GitHub](https://github.com/jbramwell/VSTS-Tools/issues)