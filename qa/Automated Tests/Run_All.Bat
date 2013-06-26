@echo off

rem Create result directory.
if not exist out md out

set operation=Test QA-001
echo %Operation%...
"..\..\Output\ZipSolution.Console.exe" "SolutionFile=Tasks\QA-Test-001.xml"
IF %ERRORLEVEL% NEQ 0 goto Error
echo %operation% - OK

set operation=Test QA-002
echo %Operation%...
"..\..\Output\ZipSolution.Console.exe" "SolutionFile=Tasks\QA-Test-002.xml"
IF %ERRORLEVEL% NEQ 0 goto Error
echo %operation% - OK

set operation=Test QA-003
echo %Operation%...
SET LOG_FILE=%~n0 003.log
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\Msbuild Tasks\QA-Test-003.proj ^
	/Target:Main ^
	"/property:root=%cd%\\" ^
	"/l:FileLogger,Microsoft.Build.Engine;logfile=%LOG_FILE%;append=false;encoding=utf-8"
IF %ERRORLEVEL% NEQ 0 goto Error
echo %operation% - OK

Goto AllEnd

:Error
echo Failed %operation%.

:AllEnd

@echo on
