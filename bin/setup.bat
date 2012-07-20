@echo off

REM This script installs a script# build (over what the msi installs)
REM It must be run within an Administrator command prompt.

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
