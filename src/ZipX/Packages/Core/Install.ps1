param($installPath, $toolsPath, $package, $project)

Import-Module (Join-Path $toolsPath "Reset.psm1")

function Compute-RelativePath ($basePath, $referencePath) {
  $baseUri = New-Object -typename System.Uri -argumentlist $basePath
  $referenceUri = New-Object -typename System.Uri -argumentlist $referencePath

  $relativeUri = $baseUri.MakeRelativeUri($referenceUri)
  $relativePath = [System.Uri]::UnescapeDataString($relativeUri.ToString()).Replace('/', '\')
  return $relativePath
}

# remove placeholder file
$placeholder = "ScriptSharp.PlaceHolder.txt"
$project.ProjectItems.Item($placeholder).Remove()
Split-Path $project.FullName -parent | Join-Path -ChildPath $placeholder | Remove-Item

# Get the msbuild object associated with the project
Add-Type -AssemblyName "Microsoft.Build, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
$msbuild = [Microsoft.Build.Evaluation.ProjectCollection]::GlobalProjectCollection.GetLoadedProjects($project.FullName) | Select-Object -First 1

# first remove any existing import reference
Reset-Project $msbuild

# get a relative reference to the targets file in the package's tools directory
# and add it to the project
$targetsAbsolutePath = Join-Path $toolsPath "ScriptSharp.targets"
$targetsRelativePath = Compute-RelativePath $project.FullName $targetsAbsolutePath
$import = $msbuild.Xml.AddImport($targetsRelativePath)
$import.Condition = "Exists('" + $targetsRelativePath + "')"

# finally save the project
$project.Save()
