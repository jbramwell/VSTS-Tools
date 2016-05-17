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
  $system = get-wmiobject Win32_ComputerSystem
  $timeZoneInfo = [TimeZoneInfo]::Local
  $OSInfo = Get-WmiObject Win32_OperatingSystem

  Write-Output(" ")
  Write-Output("SERVER")
  Write-Output("------")
  Write-Output("Computer Name:                 $($result.PSComputerName)")
  Write-Output("Manufacturer:                  $($system.Manufacturer)")
  Write-Output("Model:                         $($system.Model)")
  Write-Output("# of Processors:               $($system.NumberOfProcessors)")
  Write-Output("# of Logical Processors:       $($system.NumberOfLogicalProcessors)")

  Write-Output(" ")
  Write-Output("OPERATING SYSTEM")
  Write-Output("----------------")
  Write-Output("Operating System:              $($result.Caption)")
  Write-Output("Operating System Version:      $($result.Version)")
  Write-Output("OS Service Pack Version:       {0}.{1}" -f $result.ServicePackMajorVersion, $result.ServicePackMinorVersion)
  Write-Output("OS Install Date:               {0}" -f ([WMI]'').ConvertToDateTime($OSInfo.InstallDate))
  Write-Output("Last Bootup Time:              {0}" -f ([WMI]'').ConvertToDateTime($OSInfo.LastBootUpTime))
  Write-Output("OS Language:                   $($result.OSLanguage)")
  Write-Output("Locale:                        $($result.Locale)")
  Write-Output("System Directory:              $($result.SystemDirectory)")
  Write-Output("Windows Directory:             $($result.WindowsDirectory)")

  Write-Output(" ")
  Write-Output("TIME ZONE INFORMATION")
  Write-Output("---------------------")
  Write-Output("ID:                            $($timeZoneInfo.Id)")
  Write-Output("DisplayName:                   $($timeZoneInfo.DisplayName)")
  Write-Output("StandardName:                  $($timeZoneInfo.StandardName)")
  Write-Output("DaylightName:                  $($timeZoneInfo.DaylightName)")
  Write-Output("BaseUtcOffset:                 $($timeZoneInfo.BaseUtcOffset)")
  Write-Output("Supports Daylight Saving Time: $($timeZoneInfo.SupportsDaylightSavingTime)")

  Write-Output(" ")
  Write-Output("SYSTEM MEMORY")
  Write-Output("-------------")
  Write-Output("Total Memory:                  {0:###,###,###,###.0} GB" -f ($result.TotalVisibleMemorySize / (1048576)))
  Write-Output("Free Memory:                   {0:###,###,###,###.0} GB" -f ($result.FreePhysicalMemory / (1048576)))

  Write-Output(" ")
  Write-Output("SYSTEM DRIVES")
  Write-Output(" ")
  Write-Output("DRIVE      VOLUME                           FREE           TOTAL")
  Write-Output("-----      -------                  ------------    ------------")

  $drives = Get-PSDrive | 
       Where-Object {$_.Provider -Like "*\FileSystem"} |
       Sort-Object -Property Name

  $drives | ForEach-Object {Write-Output("{0} {1}  {2} GB {3} GB" -f 
      ($_.Name + ":").PadRight(10, " "), 
       $_.Description.PadRight(20, " "), 
      ($_.Free / 1073741824).ToString("###,###,###,##0.0").PadLeft(12, " "), 
      (($_.Free + $_.Used) / 1073741824).ToString("###,###,###,##0.0").PadLeft(12, " "))}

  Get-CimInstance -ClassName win32_operatingsystem | select csname, lastbootuptime
}