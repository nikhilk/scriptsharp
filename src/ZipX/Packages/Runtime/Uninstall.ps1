param($installPath, $toolsPath, $package, $project)

Import-Module (Join-Path $toolsPath "Reset.psm1")

# Get the msbuild object associated with the project and add an import
Add-Type -AssemblyName "Microsoft.Build, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
$msbuild = [Microsoft.Build.Evaluation.ProjectCollection]::GlobalProjectCollection.GetLoadedProjects($project.FullName)[0]

# remove import reference
Reset-Project $msbuild

# and then save the project
$project.Save()
