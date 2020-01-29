[string]$debugonly = $env:INPUT_DEBUGONLY

Write-Verbose "Entering: listapps.ps1"
Write-Verbose "  debugonly: $debugonly"

# Import the Task.Common dll that has all the cmdlets we need for Build
import-module "Microsoft.TeamFoundation.DistributedTask.Task.Common"

if ($debugonly -eq "false" -or (($debugonly -eq "true") -and ($env:SYSTEM_DEBUG -eq "true")))
{
  Function IIf($If, $Right, $Wrong) {If ($If) {$Right} Else {$Wrong}}

  Write-Output " "
  Write-Output "Installed Applications"
  Write-Output "----------------------"
  $children = Get-ChildItem -Path HKLM:SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall |
     Get-ItemProperty |
     Where-Object {$_.DisplayName -ne $null} |
     Sort-Object -Property DisplayName |
     Select-Object -Property DisplayName, DisplayVersion, InstallDate, EstimatedSize, Publisher, "---------------------"

  $count = 0
  $children | ForEach-Object {$count = $count + 1; Write-Output("{0} [{1}]" -f $_.DisplayName, (IIf ($_.DisplayVersion -eq $null) "No Version Information" $_.DisplayVersion))}
  Write-Output "--------------------------"
  Write-Output("{0} applications installed." -f $count)
}