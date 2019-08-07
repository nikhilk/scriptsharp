
Push-Location Env:
$profilePath = $env:USERPROFILE
Pop-Location

$nugetCache = Join-Path $profilePath .nuget\packages -Resolve

Push-Location $nugetCache
Get-ChildItem -Directory | Where-Object -Property Name -Like "DSharp.*" | Remove-Item -Force -Recurse
Pop-Location