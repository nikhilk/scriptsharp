@echo off
if not exist ..\..\..\bin\Packages mkdir ..\..\..\bin\Packages

..\..\..\tools\bin\nuget pack Core.nuspec -OutputDirectory ..\..\..\bin\Packages -NoPackageAnalysis

..\..\..\tools\bin\nuget pack Testing.nuspec -OutputDirectory ..\..\..\bin\Packages -NoPackageAnalysis
..\..\..\tools\bin\nuget pack FxCop.nuspec -OutputDirectory ..\..\..\bin\Packages -NoPackageAnalysis

..\..\..\tools\bin\nuget pack Lib.HTML.nuspec -OutputDirectory ..\..\..\bin\Packages -NoPackageAnalysis
..\..\..\tools\bin\nuget pack Lib.jQuery.nuspec -OutputDirectory ..\..\..\bin\Packages -NoPackageAnalysis
..\..\..\tools\bin\nuget pack Lib.jQuery.UI.nuspec -OutputDirectory ..\..\..\bin\Packages -NoPackageAnalysis
..\..\..\tools\bin\nuget pack Lib.jQuery.Validation.nuspec -OutputDirectory ..\..\..\bin\Packages -NoPackageAnalysis
..\..\..\tools\bin\nuget pack Lib.Knockout.nuspec -OutputDirectory ..\..\..\bin\Packages -NoPackageAnalysis
..\..\..\tools\bin\nuget pack Lib.BingMaps.nuspec -OutputDirectory ..\..\..\bin\Packages -NoPackageAnalysis
