param($installPath, $toolsPath, $package, $project)

function Compute-RelativePath ($basePath, $referencePath) {
  $baseUri = New-Object -typename System.Uri -argumentlist $basePath
  $referenceUri = New-Object -typename System.Uri -argumentlist $referencePath

  $relativeUri = $baseUri.MakeRelativeUri($referenceUri)
  $relativePath = [System.Uri]::UnescapeDataString($relativeUri.ToString()).Replace('/', '\')
  return $relativePath
}

function Create-RuleElement ($doc, $id) {
  $ruleNode = $doc.CreateElement('Rule')
  $ruleNode.SetAttribute('Id', $id)
  $ruleNode.SetAttribute('Action', 'Warning')
  return $ruleNode
}

# remove placeholder file
$placeholder = "ScriptSharp.PlaceHolder.txt"
$project.ProjectItems.Item($placeholder).Remove()
Split-Path $project.FullName -parent | Join-Path -ChildPath $placeholder | Remove-Item

# compute the relative path to the tools folder we'll be adding to the ruleset
$ruleSetFilePath = Split-Path $project.FullName -parent | Join-Path -ChildPath 'Properties\FxCop.ruleset'
$rulePath = Compute-RelativePath $ruleSetFilePath $toolsPath

# get the ruleset file associated with the project
$ruleSetDoc = New-Object xml
$ruleSetDoc.Load($ruleSetFilePath)
$ruleSetNode = $ruleSetDoc.RuleSet
$ruleHintPathsNode = $ruleSetNode.SelectSingleNode('RuleHintPaths')
if ($ruleHintPathsNode -eq $null) {
  $ruleHintPathsNode = $ruleSetDoc.CreateElement('RuleHintPaths')
  $ruleSetNode.InsertAfter($ruleHintPathsNode, $null)
}

# add a path for the where the fxcop rules assembly exists
$pathNode = $ruleSetDoc.CreateElement('Path')
$pathNode.AppendChild($ruleSetDoc.CreateTextNode($rulePath))
$ruleHintPathsNode.AppendChild($pathNode)

# add the rules
$rule1 = Create-RuleElement $ruleSetDoc 'SS0001'
$rule2 = Create-RuleElement $ruleSetDoc 'SS0002'
$rule3 = Create-RuleElement $ruleSetDoc 'SS0003'
$rulesNode = $ruleSetNode.Rules
$rulesNode.AppendChild($rule1)
$rulesNode.AppendChild($rule2)
$rulesNode.AppendChild($rule3)


# finally save the ruleset file
$ruleSetDoc.Save($ruleSetFilePath)
