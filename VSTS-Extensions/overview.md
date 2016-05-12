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
This extension allows you to set the retention for a specific build to *Keep Forever*.

* Target Branch - specifies the name of the branch that must be built in order for the task to run. For example, if you set the Target Branch to 'master' then the build will be set to **keep forever** only when the master branch is built.
* Execute on Debug Only - if checked, the task will execute only if **system.debug** is set to **true**.

![VSTS-List Variables Image](https://github.com/jbramwell/VSTS-Tools/blob/master/VSTS-Extensions/screenshots/keep.png?raw=true)


## VSTS-Keep
This extension provides you with a list of all applications installed on the build agent at the time the build is executed.

* Execute on Debug Only - if checked, the task will execute only if **system.debug** is set to **true**.

![VSTS-List Variables Image](https://github.com/jbramwell/VSTS-Tools/blob/master/VSTS-Extensions/screenshots/ListApps.png?raw=true)

# Road Map
|Release|Description                                |Status    |
|-------|-------------------------------------------|----------|
| 1.0.0 | Initial release                           |Completed |
| 1.1.0 | VSTS-Keep task                            |Completed |
| 1.2.0 | VSTS-List-Apps (list installed apps)      |Completed |
|       | VSTS-List-System-Specs                    |          |
|       | Node support (currently PowerShell only). |          |
|       | TBD... (based on requests)                |          ||

# Contact Us
* [Follow us on Twitter](https://twitter.com/moonspacelabs)
* [File an issue on GitHub](https://github.com/jbramwell/VSTS-Tools/issues)