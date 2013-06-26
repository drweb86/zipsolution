using System;
using System.IO;
using BULocalization;
using ZipSolution.Core.Configuration;
using ZipSolution.Core.Controller;
using ZipSolution.Core.Filters;

namespace ZipSolution.Core.Commands
{
    /// <summary>
    /// Processes command line arguments.
    /// </summary>
    class PreprocessArgumentsCommand
    {
        #region Constants

        const string _HelpOnCommands = "AnswerForFilterByDateStartTimeRequestDialogIsWeekAgo;\n" +
            "\"LastChangeTime=MM/DD/YYYY hh:mm:ss\";\n" +
            "Password=<your password>;\n" +
            "UseReleaseConfiguration;\n" +
            "\"Project=<my project title>\";\n" +
            "\"SolutionFile=<my solution file>\";\n" +
            "\"Version=<new version>\";\n" +
            "\"ExtractVersionFromAssemblyInfoCsFile=<path to AssemblyInfo.cs>\";\n" +
            "\"WaitMsec=<amount of msec>\";\n" +
            "\"ExtractVersionFromAssemblyFile=<path to assembly>\".";

        #endregion

        #region Public Methods

        public ProcessingContext PreprocessArgument(CommonController context, string[] args, out bool isValid)
        {
            var processingContext = new ProcessingContext();
            if (args != null && args.Length > 0)
            {
                foreach (string arg in args)
                {
                    if (arg == CommandLineArguments.AnswerForFilterByDateStartTimeRequestDialogIsWeekAgo)
                    {
                        processingContext.PredefinedDateTimeForDateFilterStartTimeRequestDialog = DateTime.Now - new TimeSpan(7, 0, 0, 0);
                    }
                    else if (arg.StartsWith(CommandLineArguments.Password) && arg.Length > CommandLineArguments.Password.Length)
                    {
                        processingContext.Password = arg.Substring(CommandLineArguments.Password.Length);
                    }
                    else if (arg.StartsWith(CommandLineArguments.LastChangeTime) && arg.Length > CommandLineArguments.LastChangeTime.Length)
                    {
                        var lastChangeTime = arg.Substring(CommandLineArguments.LastChangeTime.Length);
                        DateTime result;
                        if (CommandHelper.ParseDateTime(lastChangeTime, out result))
                        {
                            processingContext.LastChangeTime = result;
                        }
                    }
                    else if (arg == CommandLineArguments.OpenArchiveAfterPacking)
                    {
                        Settings.OpenArchiveAfterPacking = true;
                    }
                    else if (arg == CommandLineArguments.UseReleaseConfiguration)
                    {
                        processingContext.UseReleaseConfiguration = true;
                    }
                    else if (arg.StartsWith(CommandLineArguments.ExtractVersionFromAssemblyFile) && arg.Length > CommandLineArguments.ExtractVersionFromAssemblyFile.Length)
                    {
                        processingContext.ExtractVersionFromAssemblyFile = arg.Substring(CommandLineArguments.ExtractVersionFromAssemblyFile.Length);
                    }
                    else if (arg.StartsWith(CommandLineArguments.ExtractVersionFromAssemblyInfoCsFile) && arg.Length > CommandLineArguments.ExtractVersionFromAssemblyInfoCsFile.Length)
                    {
                        processingContext.ExtractVersionFromAssemblyInfoCsFile = arg.Substring(CommandLineArguments.ExtractVersionFromAssemblyInfoCsFile.Length);
                    }
                    else if (arg.StartsWith(CommandLineArguments.WaitMsec) && arg.Length > CommandLineArguments.WaitMsec.Length)
                    {
                        processingContext.WaitMsec = int.Parse(arg.Substring(CommandLineArguments.WaitMsec.Length));
                    }
                    else if (arg.StartsWith(CommandLineArguments.Version) && arg.Length > CommandLineArguments.Version.Length)
                    {
                        processingContext.PredefinedAnswerForVersionRequestDialog = arg.Substring(CommandLineArguments.Version.Length);
                    }
                    else if (arg.StartsWith(CommandLineArguments.Project) && arg.Length > CommandLineArguments.Project.Length)
                    {
                        processingContext.PredefinedProjectToProcess = arg.Substring(CommandLineArguments.Project.Length);
                    }
                    else if (arg.StartsWith(CommandLineArguments.SolutionFile) && arg.Length > CommandLineArguments.SolutionFile.Length + 1)
                    {
                        try
                        {
                            processingContext.PredefinedSolutionFileToProcess = new FileInfo(arg.Substring(CommandLineArguments.SolutionFile.Length)).FullName;
                        }
                        catch (Exception e)
                        {
                            context.ShowErrorBox(arg.Substring(CommandLineArguments.SolutionFile.Length) + ": " + e);
                            isValid = false;
                            return null;
                        }
                    }
                    else
                    {
                        context.ShowErrorBox(Translation.Current[80], arg);// Unknown argument passed: {0}
                        context.ShowHelp(_HelpOnCommands);
                        isValid = false;
                        return null;
                    }
                }
            }
            isValid = true;
            return processingContext;
        }

        #endregion
    }
}
