@echo off

REM This script installs a script# build (over what the msi installs)
REM It must be run within an Administrator command prompt.

@echo Setting up templates...

set IDEDir="%VSINSTALLDIR%"Common7\IDE\
set ProjDir="%VSINSTALLDIR%"Common7\IDE\ProjectTemplates\CSharp\Script#
set ItemDir="%VSINSTALLDIR%"Common7\IDE\ItemTemplates\CSharp\Script#

if not exist %ProjDir% mkdir %ProjDir%
if not exist %ItemDir% mkdir %ItemDir%

copy /y Debug\Templates\Script#.VSTDIR %ProjDir%
copy /y Debug\Templates\ProjectTemplates\ClassLibrary.zip %ProjDir%
copy /y Debug\Templates\ProjectTemplates\jQueryClassLibrary.zip %ProjDir%
copy /y Debug\Templates\ProjectTemplates\UnitTest.zip %ProjDir%
copy /y Debug\Templates\ProjectTemplates\ImportLibrary.zip %ProjDir%
copy /y Debug\Templates\Script#.VSTDIR %ItemDir%
copy /y Debug\Templates\ItemTemplates\Class.zip %ItemDir%
copy /y Debug\Templates\ItemTemplates\Page.zip %ItemDir%
copy /y Debug\Templates\ItemTemplates\jQueryPage.zip %ItemDir%
copy /y Debug\Templates\ItemTemplates\jQueryPlugin.zip %ItemDir%
copy /y Debug\Templates\ItemTemplates\Resource.zip %ItemDir%
copy /y Debug\Templates\ItemTemplates\Scriptlet.zip %ItemDir%
copy /y Debug\Templates\ItemTemplates\TestClass.zip %ItemDir%
%IDEDir%\devenv.exe /installvstemplates
