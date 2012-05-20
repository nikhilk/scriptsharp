@echo off

if not exist %1\bin\Release\Setup mkdir %1\bin\Release\Setup
del /q %1\bin\Release\Setup\*.*

@echo .

@echo .
@echo Compiling...
%1\tools\bin\Wix\candle.exe -nologo -sw1068 -out %1\bin\Release\Setup\ ScriptSharp.wxs

@echo .
@echo Linking...
%1\tools\bin\Wix\light.exe -nologo -sw1076 %1\bin\Release\Setup\*.wixobj -ext WixNetFxExtension -ext WixUIExtension -b %1\bin\Release -out %1\bin\Release\Setup\ScriptSharp.msi

@echo .
@echo Cleaning up...
del /q %1\bin\Release\Setup\*.wixobj
del /q %1\bin\Release\Setup\*.wixpdb
