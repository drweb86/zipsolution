using System;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace ZipSolution.Commands
{
    /// <summary>
    /// Copies script to clipboard.
    /// </summary>
    class CopyScriptCommand
    {
        #region Consts

        private const string _ConsoleTool = "ZipSolution.Console.exe";

        private const string _ps1ScriptFirstPart =
            "$application=\"{0}\"" + "\r\n" +
            "$solutionName=\"{1}\"" + "\r\n";

        private const string _ps1ScriptSecondPart =
"\r\n" +
"$arguments=[string]::Format('\"Project={0}\"', $solutionName)" + "\r\n" +
"$process = [Diagnostics.Process]::Start($application, $arguments)" + "\r\n" +
"do { } while (!$process.HasExited)" + "\r\n" +
"if ($process.ExitCode -eq 0)" + "\r\n" +
"{" + "\r\n" +
"	\"Successful\"" + "\r\n" +
"}" + "\r\n" +
"else" + "\r\n" +
"{" + "\r\n" +
"	\"Failed\"" + "\r\n" +
"}" + "\r\n";

        private const string _BatScript = "\"{0}\" \"Project={1}\"";
        private const string _BatScriptBody = @"
@echo off
{0}

IF %ERRORLEVEL%==0 goto ZipSolutionOK

rem ERROR
echo Finished with error!
goto ZipSolutionEnd

rem OK
:ZipSolutionOK
echo Finished successfuly
goto ZipSolutionEnd

:ZipSolutionEnd
@echo on
";
        #endregion

        public void CopyScript(Controller controller, ScriptType type, string solutionTitle)
        {
            var consoleTool = Path.Combine(
                Path.GetDirectoryName(Application.ExecutablePath),
                _ConsoleTool);

            switch (type)
            {
                case ScriptType.Cmd:
                case ScriptType.Batch:
                    SetToCliboardFailSafe(
                        string.Format(_BatScriptBody, 
                            string.Format(
                                CultureInfo.CurrentCulture,
                                _BatScript,
                                consoleTool,
                                solutionTitle)));
                    break;
                case ScriptType.PowerShell:
                    SetToCliboardFailSafe(
                        string.Format(_ps1ScriptFirstPart, consoleTool, solutionTitle) +
                        _ps1ScriptSecondPart);
                    break;
                default:
                    throw new NotSupportedException(type.ToString());
            }
        }

        #region Private Methods

        private static void SetToCliboardFailSafe(string text)
        {
            try
            {
                Clipboard.SetDataObject(text);
            }
            catch (System.Runtime.InteropServices.ExternalException) { }
        }

        #endregion
    }
}
