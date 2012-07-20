param($installPath, $toolsPath, $package, $project)

Import-Module (Join-Path $toolsPath "Cleanup.psm1")

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

# save any out-standing changes to the project first before modifying the project file
$project.Save()

# load project file as xml document
$doc = New-Object System.Xml.XmlDocument
$doc.Load($project.FullName)
$namespace = "http://schemas.microsoft.com/developer/msbuild/2003"

# remove any old import reference in case one exists
Cleanup-Project $doc $namespace

# add targets import by building a relative reference to targets file in package tools directory
$targetsAbsolutePath = Join-Path $toolsPath "ScriptSharp.targets"
$targetsRelativePath = Compute-RelativePath $project.FullName $targetsAbsolutePath
$importNode = $doc.CreateElement('Import', $namespace)
$importNode.SetAttribute('Project', $targetsRelativePath)
$doc.Project.AppendChild($importNode)

# finally save the project
$doc.Save($project.FullName)
