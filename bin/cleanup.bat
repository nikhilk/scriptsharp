@echo off

REM This script cleans up what setup.bat does.
REM It must be run within an Administrator command prompt.

@echo Cleaning up templates...

set IDEDir="%VSINSTALLDIR%"\Common7\IDE
set ProjDir="%VSINSTALLDIR%"Common7\IDE\ProjectTemplates\CSharp\Script#
set ItemDir="%VSINSTALLDIR%"Common7\IDE\ItemTemplates\CSharp\Script#

rd /s /q %ProjDir%
rd /s /q %ItemDir%

%IDEDir%\devenv.exe /installvstemplates
