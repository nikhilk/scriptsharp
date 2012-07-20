param($installPath, $toolsPath, $package, $project)

Import-Module (Join-Path $toolsPath "Cleanup.psm1")

# save any unsaved changes first
$project.Save()

# load project file as xml document
$doc = New-Object System.Xml.XmlDocument
$doc.Load($project.FullName)
$namespace = "http://schemas.microsoft.com/developer/msbuild/2003"

# remove import reference
Cleanup-Project $doc $namespace

# save changes
$doc.Save($project.FullName)

# reload the project since we made changes to the csproj
$project.DTE.ExecuteCommand("Project.ReloadProject")