[string]$rootdir = $env:INPUT_ROOTDIR
[string]$debugonly = $env:INPUT_DEBUGONLY

Write-Verbose "Entering: listfiles.ps1"
Write-Verbose "  rootdir = $rootdir"
Write-Verbose "  debugonly = $debugonly"

# Import the Task.Common dll that has all the cmdlets we need for Build
import-module "Microsoft.TeamFoundation.DistributedTask.Task.Common"

if(!$rootdir)
{
    $rootdir = ".";
}

Write-Verbose "Setting root directory to $rootdir"

if ($debugonly -eq "false" -or (($debugonly -eq "true") -and ($env:SYSTEM_DEBUG -eq "true")))
{
    dir $rootdir -r  | % { if ($_.PsIsContainer) { $_.FullName + "\" } else { $_.FullName } }
}