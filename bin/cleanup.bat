@echo off

REM This script cleans up what setup.bat does.
REM It must be run within an Administrator command prompt.

@echo Cleaning GAC entries...
gacutil /nologo /uf ScriptSharp
gacutil /nologo /uf ScriptSharp.Build
gacutil /nologo /uf ScriptSharp.Testing
gacutil /nologo /uf ScriptSharp.VisualStudio

set InstallDir=%ProgramFiles(x86)%
if "%InstallDir%" == "" set InstallDir=%ProgramFiles%

@echo Removing script# folder...
rd /s /q "%InstallDir%\ScriptSharp\v1.0"

if "%1" neq "includeTemplates" goto Done

:Templates
@echo Cleaning up templates...
set IDEDir="%VSINSTALLDIR%"\Common7\IDE
rd /s /q "%IDEDir%"\ProjectTemplates\CSharp\Script#
rd /s /q "%IDEDir%"\ItemTemplates\CSharp\Script#
%IDEDir%\devenv.exe /installvstemplates

:Done
