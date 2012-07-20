@echo off

REM This script cleans up what setup.bat does.
REM It must be run within an Administrator command prompt.

@echo Cleaning up templates...

set IDEDir="%VSINSTALLDIR%"\Common7\IDE

rd /s /q "%IDEDir%"\ProjectTemplates\CSharp\Script#
rd /s /q "%IDEDir%"\ItemTemplates\CSharp\Script#

%IDEDir%\devenv.exe /installvstemplates
