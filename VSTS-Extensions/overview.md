## VSTS-Tools
This extension provides several build tasks that can help you diagnose your builds as well as control the retention of completed builds.

## VSTS-Tools List Apps
This extension provides you with a list of all applications installed on the build agent at the time the build is executed.

* Execute on Debug Only - if checked, the task will execute only if **system.debug** is set to **true**.

![VSTS-Tools List Apps Image](https://github.com/jbramwell/VSTS-Tools/blob/master/VSTS-Extensions/screenshots/ListApps.png?raw=true)

## VSTS-Tools List Files
This extension will list out (in the log) all files beneath the folder specified as the *Root Folder*. There are two parameters that can be set with this task:

* Root Directory - all files and folders beneath the root directory will be listed (recursively).
* Execute on Debug Only - if checked, the task will execute only if **system.debug** is set to **true**.

![VSTS-Tools List Files Image](https://github.com/jbramwell/VSTS-Tools/blob/master/VSTS-Extensions/screenshots/ListFiles.png?raw=true)

## VSTS-Tools List Variables
This extension will list out (in the log) all variables that are defined at the time this extension is executed. There is one parameter that can be set with this task:

* Execute on Debug Only - if checked, the task will execute only if **system.debug** is set to **true**.

![VSTS-Tools List Variables Image](https://github.com/jbramwell/VSTS-Tools/blob/master/VSTS-Extensions/screenshots/ListVariables.png?raw=true)

## VSTS-Tools Keep
This extension allows you to set the retention for a specific build to *Keep Forever*.

* Target Branch - specifies the name of the branch that must be built in order for the task to run. For example, if you set the Target Branch to 'master' then the build will be set to **keep forever** only when the master branch is built.
* Execute on Debug Only - if checked, the task will execute only if **system.debug** is set to **true**.

![VSTS-Tools Keep Image](https://github.com/jbramwell/VSTS-Tools/blob/master/VSTS-Extensions/screenshots/keep.png?raw=true)

**IMPORTANT!** Before you can make use of the *VSTS-Tools Keep* task, you must first configure your account to allow the use of the build process OAuth token. To do this, go to the **Options** tab of the build definition and select *Allow Scripts to Access OAuth Token*.

![VSTS-Tools Keep Image](https://github.com/jbramwell/VSTS-Tools/blob/master/VSTS-Extensions/screenshots/OAuth.png?raw=true)

## Road Map
|Release|Description                                |Status    |
|-------|-------------------------------------------|----------|
| 1.0.0 | Initial release                           |Completed |
| 1.1.0 | VSTS-Keep task                            |Completed |
| 1.2.0 | VSTS-List-Apps (list installed apps)      |Completed |
|       | VSTS-List-System-Specs                    |          |
|       | Node support (currently PowerShell only). |          |
|       | TBD... (based on requests)                |          ||

## Feedback and Support
If you like this set of extensions, please leave a review and rating. If you have any suggestions and/or problems, please [file an issue so we can get it resolved](https://github.com/jbramwell/VSTS-Tools/issues).
## Contact Us
* [Follow us on Twitter](https://twitter.com/moonspacelabs)
* [Follow us on Facebook](https://www.facebook.com/MoonspaceLabs/)