param (
    [string]$debugonly
)

Write-Verbose "Entering: listsystemspecs.ps1"
Write-Verbose "  debugonly: $debugonly"

# Import the Task.Common dll that has all the cmdlets we need for Build
import-module "Microsoft.TeamFoundation.DistributedTask.Task.Common"

if ($debugonly -eq "false" -or (($debugonly -eq "true") -and ($env:SYSTEM_DEBUG -eq "true")))
{
  Write-Output("Hello, World!")
}