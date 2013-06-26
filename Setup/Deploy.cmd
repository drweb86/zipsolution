@echo off

if exist output rd output /S /Q
if exist ..\output rd ..\output /S /Q
md ..\output
md output

set msBuild=%windir%\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe
set configuration=Release
set target=Rebuild

set operation=Build Zip Solution
echo %Operation%...
"%msbuild%" "..\src\ZipSolution.sln" ^
	/Target:"%target%" ^
	/p:Configuration="%configuration%"
IF %ERRORLEVEL% NEQ 0 goto Error

set operation=Prepare binaries
echo %Operation%...
..\Output\ZipSolution.Console.exe "SolutionFile=SelfDeploy-Binaries.xml" "ExtractVersionFromAssemblyInfoCsFile=..\src\ZipSolution.UI\AssemblyInfo.cs"
IF %ERRORLEVEL% NEQ 0 goto Error

set operation=Prepare sources
echo %Operation%...
..\Output\ZipSolution.Console.exe "SolutionFile=SelfDeploy-Sources.xml" "ExtractVersionFromAssemblyFile=..\Output\ZipSolution.exe"
IF %ERRORLEVEL% NEQ 0 goto Error

set operation=Building setup.
echo %Operation%...
"C:\Program Files (x86)\Inno Setup 5\ISCC.exe" InnoSetup.iss
IF %ERRORLEVEL% NEQ 0 goto Error

Goto AllEnd

:Error
echo Failed %operation%.
pause

:AllEnd

@echo on
