## VSTS-Tools
This extension provides several build tasks that can help you diagnose your builds as well as control the retention of completed builds. The tasks are also useful for keeping a running history of environment variables, files and installed apps on your build agents.

## VSTS-Tools Comments
![Works with VSTS](https://raw.githubusercontent.com/jbramwell/VSTS-Tools/master/VSTS-Extensions/images/VSTS_light.png) ![Works with TFS 2015](https://raw.githubusercontent.com/jbramwell/VSTS-Tools/master/VSTS-Extensions/images/TFS_2015_light.png)

This extension allows you to provide some comments about the build definition. For example, you might include information about the order of build tasks and why they are ordered the way they are. You might provide information about the source of some of the variable values. You can include information about any constraints (e.g. time windows) as to when the build can run, etc. Essentially, you can provide whatever comments you want :-)

There are two parameters that can be set with this task:

* Comments - the text of the build comments.
* Include Comments in Log - If checked, the comments will be included in the log file; Otherwise, you will only see the comments in the build definition.

![VSTS-Tools Comments](https://raw.githubusercontent.com/jbramwell/VSTS-Tools/master/VSTS-Extensions/screenshots/Comments.png)

## VSTS-Tools Keep
![Works with VSTS](https://raw.githubusercontent.com/jbramwell/VSTS-Tools/master/VSTS-Extensions/images/VSTS_light.png)

>**NOTE**: This task does not yet work with Team Foundation Server 2015 (on-premises). Once TFS has been updated to support this task, the task will be enabled for use on TFS.

This extension allows you to set the retention for a build to *Keep Forever*. This is especially handy if you are making use of a 3rd party release tool (e.g. Octopus Deploy) or a custom release process and you want to set the retention after completing the deployment-related build tasks.

There are two parameters that can be set with this task:

* Target Branch - specifies the name of the branch that must be built in order for the task to run. For example, if you set the Target Branch to 'master' then the build will be set to **keep forever** only when the master branch is built.
* Execute on Debug Only - if checked, the task will execute only if **system.debug** is set to **true**.

>**IMPORTANT:** Before you can make use of the *VSTS-Tools Keep* task, you must first configure your account to allow the use of the build process OAuth token. To do this, go to the **Options** tab of the build definition and select **Allow Scripts to Access OAuth Token**.

![VSTS-Tools Keep Image](https://github.com/jbramwell/VSTS-Tools/blob/master/VSTS-Extensions/screenshots/OAuth.png?raw=true)

![VSTS-Tools Keep Image](https://raw.githubusercontent.com/jbramwell/VSTS-Tools/master/VSTS-Extensions/screenshots/keep.png)

## VSTS-Tools List Apps
![Works with VSTS](https://raw.githubusercontent.com/jbramwell/VSTS-Tools/master/VSTS-Extensions/images/VSTS_light.png) ![Works with TFS 2015](https://raw.githubusercontent.com/jbramwell/VSTS-Tools/master/VSTS-Extensions/images/TFS_2015_light.png)

This extension provides you with a list of all applications installed on the build agent at the time the build is executed. This task is especially useful on hosted build agents where you do not have direct access to the file system.

There is one parameter that can be set with this task:

* Execute on Debug Only - if checked, the task will execute only if **system.debug** is set to **true**.

![VSTS-Tools List Apps Image](https://raw.githubusercontent.com/jbramwell/VSTS-Tools/master/VSTS-Extensions/screenshots/ListApps.png)

## VSTS-Tools List Files
![Works with VSTS](https://raw.githubusercontent.com/jbramwell/VSTS-Tools/master/VSTS-Extensions/images/VSTS_light.png) ![Works with TFS 2015](https://raw.githubusercontent.com/jbramwell/VSTS-Tools/master/VSTS-Extensions/images/TFS_2015_light.png)

This extension will list out (in the log) all files beneath the folder specified as the *Root Folder*. This task can be especially useful on hosted build agents where you do not have direct access to the file system.

There are two parameters that can be set with this task:

* Root Directory - all files and folders beneath the root directory will be listed (recursively).
* Execute on Debug Only - if checked, the task will execute only if **system.debug** is set to **true**.

![VSTS-Tools List Files Image](https://raw.githubusercontent.com/jbramwell/VSTS-Tools/master/VSTS-Extensions/screenshots/ListFiles.png)

## VSTS-Tools List System Info
![Works with VSTS](https://raw.githubusercontent.com/jbramwell/VSTS-Tools/master/VSTS-Extensions/images/VSTS_light.png) ![Works with TFS 2015](https://raw.githubusercontent.com/jbramwell/VSTS-Tools/master/VSTS-Extensions/images/TFS_2015_light.png)

This extension will list out (in the log) various system-related information and settings. This task can be especially useful on hosted build agents where you do not have direct access to the build server.

There are two parameters that can be set with this task:

* Target Branch - specifies the name of the branch that must be built in order for the task to run. For example, if you set the Target Branch to 'master' then the build will be set to **keep forever** only when the master branch is built.
* Execute on Debug Only - if checked, the task will execute only if **system.debug** is set to **true**.

![VSTS-Tools List System Info Image](https://raw.githubusercontent.com/jbramwell/VSTS-Tools/master/VSTS-Extensions/screenshots/ListSystemInfo.png)

## VSTS-Tools List Variables
![Works with VSTS](https://raw.githubusercontent.com/jbramwell/VSTS-Tools/master/VSTS-Extensions/images/VSTS_light.png) ![Works with TFS 2015](https://raw.githubusercontent.com/jbramwell/VSTS-Tools/master/VSTS-Extensions/images/TFS_2015_light.png)

This extension will list out (in the log) all variables that are defined at the time this extension is executed. This task can be especially useful on hosted build agents where you do not have direct access to the file system.

There is one parameter that can be set with this task:

* Execute on Debug Only - if checked, the task will execute only if **system.debug** is set to **true**.

![VSTS-Tools List Variables Image](https://raw.githubusercontent.com/jbramwell/VSTS-Tools/master/VSTS-Extensions/screenshots/ListVariables.png)

## Release History/Road Map
|Release|Description                                |
|-------|-------------------------------------------|
| 1.0.0 | Initial release                           |
|       | ...VSTS-List Files                        |
|       | ...VSTS-List Variables                    |
| 1.1.0 | VSTS-Keep task                            |
| 1.2.0 | VSTS-List-Apps                            |
| 1.3.0 | VSTS-List-System-Info                     |
| 1.3.1 | Resolved issues so tasks install on TFS   |
| 1.4.0 | VSTS-Comments task                        |
|       | TBD... (based on requests)                |

## Feedback and Support
If you like this set of extensions, please leave a review and rating. If you have any suggestions and/or problems, please [file an issue so we can get it resolved](https://github.com/jbramwell/VSTS-Tools/issues).

## Contact Us
* [Follow us on Twitter](https://twitter.com/moonspacelabs)
* [Follow us on Facebook](https://www.facebook.com/MoonspaceLabs/)
