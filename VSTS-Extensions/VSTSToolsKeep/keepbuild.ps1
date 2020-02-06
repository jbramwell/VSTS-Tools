[string]$targetbranch = $env:INPUT_TARGETBRANCH
[string]$debugonly = $env:INPUT_DEBUGONLY

Write-Verbose "Entering: keepbuild.ps1"
Write-Verbose "  targetbranch: $targetbranch"
Write-Verbose "  debugonly: $debugonly"

# Import the Task.Common dll that has all the cmdlets we need for Build
import-module "Microsoft.TeamFoundation.DistributedTask.Task.Common"

if ($debugonly -eq "false" -or (($debugonly -eq "true") -and ($env:SYSTEM_DEBUG -eq "true")))
{
    if ($env:BUILD_SOURCEBRANCHNAME -eq $targetbranch)
    {
        $uri = "$($env:SYSTEM_TEAMFOUNDATIONCOLLECTIONURI)$env:SYSTEM_TEAMPROJECT/_apis/build/builds/$($env:BUILD_BUILDID)?api-version=2.0"
        Write-Verbose "URI: $uri"
        
        $body = "{keepForever:true}"
        $result = Invoke-RestMethod -Uri $uri -Method Patch -ContentType "application/json" -Headers @{Authorization = "Bearer $env:SYSTEM_ACCESSTOKEN"} -Body $body
        
        Write-Output "RESULT: $result"
    }
}