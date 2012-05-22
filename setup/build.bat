@echo off

set _=%cd%
cd %~dp0\..\setup

if not exist ..\bin\Release\Setup mkdir ..\bin\Release\Setup
del /q ..\bin\Release\Setup\*.*

@echo .

@echo .
@echo Compiling...
..\tools\bin\Wix\candle.exe -nologo -sw1068 -out ..\bin\Release\Setup\ ScriptSharp.wxs

@echo .
@echo Linking...
..\tools\bin\Wix\light.exe -nologo -sw1076 ..\bin\Release\Setup\*.wixobj -ext WixNetFxExtension -ext WixUIExtension -b ..\bin\Release -out ..\bin\Release\Setup\ScriptSharp.msi

@echo .
@echo Cleaning up...
del /q ..\bin\Release\Setup\*.wixobj
del /q ..\bin\Release\Setup\*.wixpdb

chdir /d %_%
