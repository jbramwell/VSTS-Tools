param (
    [string]$leftOperand,
    [string]$operator,
    [string]$rightOperand
)

Write-Verbose "Entering: stopbuild.ps1"
Write-Verbose "  leftOperand = $leftOperand"
Write-Verbose "  operator = $operator"
Write-Verbose "  rightOperand = $rightOperand"

# Import the Task.Common dll that has all the cmdlets we need for Build
import-module "Microsoft.TeamFoundation.DistributedTask.Task.Common"

switch($operator)
{
  "-eq" { $answer = ($leftOperand -eq $rightOperand) }
  "-ne" { $answer = ($leftOperand -ne $rightOperand) }

  "-lt" { $answer = ($leftOperand -lt $rightOperand) }
  "-le" { $answer = ($leftOperand -le $rightOperand) }

  "-gt" { $answer = ($leftOperand -gt $rightOperand) }
  "-ge" { $answer = ($leftOperand -ge $rightOperand) }

  "-Like" { $answer = ($leftOperand -Like $rightOperand) }
  "-NotLike" { $answer = ($leftOperand -NotLike $rightOperand) }

  "-Match" { $answer = ($leftOperand -Match $rightOperand) }
  "-NotMatch" { $answer = ($leftOperand -NotMatch $rightOperand) }

  "-Contains" { $answer = ($leftOperand -Contains $rightOperand) }
  "-NotContains" { $answer = ($leftOperand -NotContains $rightOperand) }

  "-In" { $answer = ($leftOperand -In $rightOperand) }
  "-NotIn" { $answer = ($leftOperand -NotIn $rightOperand) }
}

if ($answer -eq $true)
{
    Write-Output("##vso[task.logissue type=warning;]Cancelling build based on currently selected criteria.")
    Write-Output("##vso[task.complete result=Cancelled;]")
}