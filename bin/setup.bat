@echo off

REM This script installs a script# build (over what the msi installs)
REM It must be run within an Administrator command prompt.

set InstallDir=%ProgramFiles(x86)%
if "%InstallDir%" == "" set InstallDir=%ProgramFiles%

mkdir "%InstallDir%\ScriptSharp\v1.0\Framework"
mkdir "%InstallDir%\ScriptSharp\v1.0\CodeAnalysis"

@echo Copying binaries...
copy /y Debug\ssc.exe "%InstallDir%\ScriptSharp\v1.0"
copy /y Debug\sspp.exe "%InstallDir%\ScriptSharp\v1.0"
copy /y Debug\ScriptSharp.dll "%InstallDir%\ScriptSharp\v1.0"
copy /y Debug\ScriptSharp.Build.dll "%InstallDir%\ScriptSharp\v1.0"
copy /y Debug\ScriptSharp.Testing.dll "%InstallDir%\ScriptSharp\v1.0"
copy /y Debug\ScriptSharp.VisualStudio.dll "%InstallDir%\ScriptSharp\v1.0"
copy /y Debug\ScriptSharp.FxCop.dll "%InstallDir%\ScriptSharp\v1.0\CodeAnalysis"
copy /y Debug\ScriptSharp.targets "%InstallDir%\ScriptSharp\v1.0"

@echo Adding GAC entries...
gacutil /nologo /if "%InstallDir%\ScriptSharp\v1.0\ScriptSharp.dll
gacutil /nologo /if "%InstallDir%\ScriptSharp\v1.0\ScriptSharp.Build.dll
gacutil /nologo /if "%InstallDir%\ScriptSharp\v1.0\ScriptSharp.Testing.dll"
gacutil /nologo /if "%InstallDir%\ScriptSharp\v1.0\ScriptSharp.VisualStudio.dll"

@echo Copying scripts...
copy /y ref\mscorlib.js "%InstallDir%\ScriptSharp\v1.0\Framework"
copy /y ref\mscorlib.debug.js "%InstallDir%\ScriptSharp\v1.0\Framework"

@echo Copying assemblies...
copy /y Debug\mscorlib.dll "%InstallDir%\ScriptSharp\v1.0\Framework"
copy /y Debug\mscorlib.xml "%InstallDir%\ScriptSharp\v1.0\Framework"
copy /y Debug\Script.Web.dll "%InstallDir%\ScriptSharp\v1.0\Framework"
copy /y Debug\Script.Web.xml "%InstallDir%\ScriptSharp\v1.0\Framework"
copy /y Debug\Script.jQuery.dll "%InstallDir%\ScriptSharp\v1.0\Framework"
copy /y Debug\Script.jQuery.xml "%InstallDir%\ScriptSharp\v1.0\Framework"
copy /y Debug\Script.jQuery.txt "%InstallDir%\ScriptSharp\v1.0\Framework"
copy /y Debug\Script.jQuery.UI.dll "%InstallDir%\ScriptSharp\v1.0\Framework"
copy /y Debug\Script.jQuery.UI.xml "%InstallDir%\ScriptSharp\v1.0\Framework"
copy /y Debug\Script.jQuery.UI.txt "%InstallDir%\ScriptSharp\v1.0\Framework"
copy /y Debug\Script.jQuery.History.dll "%InstallDir%\ScriptSharp\v1.0\Framework"
copy /y Debug\Script.jQuery.History.xml "%InstallDir%\ScriptSharp\v1.0\Framework"
copy /y Debug\Script.jQuery.History.txt "%InstallDir%\ScriptSharp\v1.0\Framework"
copy /y Debug\Script.jQuery.Templating.dll "%InstallDir%\ScriptSharp\v1.0\Framework"
copy /y Debug\Script.jQuery.Templating.xml "%InstallDir%\ScriptSharp\v1.0\Framework"
copy /y Debug\Script.jQuery.Templating.txt "%InstallDir%\ScriptSharp\v1.0\Framework"
copy /y Debug\Script.jQuery.Validation.dll "%InstallDir%\ScriptSharp\v1.0\Framework"
copy /y Debug\Script.jQuery.Validation.xml "%InstallDir%\ScriptSharp\v1.0\Framework"
copy /y Debug\Script.jQuery.Validation.txt "%InstallDir%\ScriptSharp\v1.0\Framework"
copy /y Debug\Script.Knockout.dll "%InstallDir%\ScriptSharp\v1.0\Framework"
copy /y Debug\Script.Knockout.xml "%InstallDir%\ScriptSharp\v1.0\Framework"
copy /y Debug\Script.Knockout.txt "%InstallDir%\ScriptSharp\v1.0\Framework"
copy /y Debug\Script.Microsoft.BingMaps.dll "%InstallDir%\ScriptSharp\v1.0\Framework"
copy /y Debug\Script.Microsoft.BingMaps.xml "%InstallDir%\ScriptSharp\v1.0\Framework"
copy /y Debug\Script.Microsoft.BingMaps.txt "%InstallDir%\ScriptSharp\v1.0\Framework"

if "%1" neq "includeTemplates" goto Done

:Templates
@echo Setting up templates...
set IDEDir="%VSINSTALLDIR%"Common7\IDE
mkdir "%IDEDir%"\ProjectTemplates\CSharp\Script#
mkdir "%IDEDir%"\ItemTemplates\CSharp\Script#
copy /y Debug\Templates\Script#.VSTDIR %IDEDir%\ProjectTemplates\CSharp\Script#
copy /y Debug\Templates\ProjectTemplates\ClassLibrary.zip %IDEDir%\ProjectTemplates\CSharp\Script#
copy /y Debug\Templates\ProjectTemplates\jQueryClassLibrary.zip %IDEDir%\ProjectTemplates\CSharp\Script#
copy /y Debug\Templates\ProjectTemplates\UnitTest.zip %IDEDir%\ProjectTemplates\CSharp\Script#
copy /y Debug\Templates\ProjectTemplates\ImportLibrary.zip %IDEDir%\ProjectTemplates\CSharp\Script#
copy /y Debug\Templates\Script#.VSTDIR %IDEDir%\ItemTemplates\CSharp\Script#
copy /y Debug\Templates\ItemTemplates\Class.zip %IDEDir%\ItemTemplates\CSharp\Script#
copy /y Debug\Templates\ItemTemplates\Page.zip %IDEDir%\ItemTemplates\CSharp\Script#
copy /y Debug\Templates\ItemTemplates\jQueryPage.zip %IDEDir%\ItemTemplates\CSharp\Script#
copy /y Debug\Templates\ItemTemplates\jQueryPlugin.zip %IDEDir%\ItemTemplates\CSharp\Script#
copy /y Debug\Templates\ItemTemplates\Resource.zip %IDEDir%\ItemTemplates\CSharp\Script#
copy /y Debug\Templates\ItemTemplates\Scriptlet.zip %IDEDir%\ItemTemplates\CSharp\Script#
copy /y Debug\Templates\ItemTemplates\TestClass.zip %IDEDir%\ItemTemplates\CSharp\Script#
%IDEDir%\devenv.exe /installvstemplates

:Done
