param (
    [string]$debugonly
)

Write-Verbose "Entering: listsystemspecs.ps1"
Write-Verbose "  debugonly: $debugonly"

# Import the Task.Common dll that has all the cmdlets we need for Build
import-module "Microsoft.TeamFoundation.DistributedTask.Task.Common"

if ($debugonly -eq "false" -or (($debugonly -eq "true") -and ($env:SYSTEM_DEBUG -eq "true")))
{
  $result = gwmi Win32_OperatingSystem 
  $timeZoneInfo = [TimeZoneInfo]::Local

  Write-Output("SERVER")
  Write-Output("------")
  Write-Output("Computer Name:                 $($result.PSComputerName)")
  Write-Output("")
  Write-Output("OPERATING SYSTEM")
  Write-Output("----------------")
  Write-Output("Operating System:              $($result.Caption)")
  Write-Output("Operating System Version:      $($result.Version)")
  Write-Output("Service Pack Version:          {0}.{1}" -f $result.ServicePackMajorVersion, $result.ServicePackMinorVersion)
  Write-Output("System Directory:              $($result.SystemDirectory)")
  Write-Output("Windows Directory:             $($result.WindowsDirectory)")
  Write-Output("")
  Write-Output("TIME ZONE INFORMATION")
  Write-Output("---------------------")
  Write-Output("ID:                            $($timeZoneInfo.Id)")
  Write-Output("DisplayName:                   $($timeZoneInfo.DisplayName)")
  Write-Output("StandardName:                  $($timeZoneInfo.StandardName)")
  Write-Output("DaylightName:                  $($timeZoneInfo.DaylightName)")
  Write-Output("BaseUtcOffset:                 $($timeZoneInfo.BaseUtcOffset)")
  Write-Output("Supports Daylight Saving Time: $($timeZoneInfo.SupportsDaylightSavingTime)")
  Write-Output("")
  Write-Output("SYSTEM MEMORY")
  Write-Output("-------------")
  Write-Output("Total Memory:                  {0:###,###,###,###.0} GB" -f ($result.TotalVisibleMemorySize / (1048576)))
  Write-Output("Free Memory:                   {0:###,###,###,###.0} GB" -f ($result.FreePhysicalMemory / (1048576)))
  Write-Output("")
  Write-Output("SYSTEM DRIVES")
  Write-Output("-------------")
  Get-PSDrive
}