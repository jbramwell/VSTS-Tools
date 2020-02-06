[string]$cwd = $env:INPUT_CWD
[string]$msg = $env:INPUT_MSG

Write-Verbose 'Entering sample.ps1'
Write-Verbose "cwd = $cwd"
Write-Verbose "msg = $msg"

# Import the Task.Common dll that has all the cmdlets we need for Build
import-module "Microsoft.TeamFoundation.DistributedTask.Task.Common"

if(!$cwd)
{
    throw (Get-LocalizedString -Key "Working directory parameter is not set")
}

if(!(Test-Path $cwd -PathType Container))
{
    throw ("$cwd does not exist");
}

Write-Verbose "Setting working directory to $cwd"
Set-Location $cwd

Write-Host $msg




