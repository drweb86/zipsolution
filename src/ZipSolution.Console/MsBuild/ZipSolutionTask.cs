using System;
using System.IO;
using Microsoft.Build.Utilities;
using ZipSolution.Core.Commands;
using ZipSolution.Core.Filters;
using ZipSolution.Core.Misc;

namespace ZipSolution.Console.MsBuild
{
    /*
    Usage sample

1. Create TestZipSolution.proj file with contents
<Project xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <UsingTask TaskName="ZipSolutionTask" AssemblyFile="D:\Проекты\zipsolution.codeplex.com\trunk\Output\ZipSolution.Console.exe" />

  <Target Name="MyTarget">
      <ZipSolutionTask AnswerForFilterByDateStartTimeRequestDialogIsWeekAgo="False" Password="" UseReleaseConfiguration="False" Project="GWC-1" SolutionFile="" Version="MS Build" LastChangeTime="" WaitMsec="0" ExtractVersionFromAssemblyInfoCsFile="" ExtractVersionFromAssemblyFile=""/>
   </Target>
</Project>
2. Run from folder with proj file:
C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild.exe    

     */
    /// <summary>
    /// Ms build integration
    /// </summary>
    public class ZipSolutionTask:Task
    {
        #region Properties

        public bool AnswerForFilterByDateStartTimeRequestDialogIsWeekAgo { get; set; }

        public string Password { get; set; }

        public bool UseReleaseConfiguration { get; set; }

        public string Project { get; set; }

        public string SolutionFile { get; set; }

        public string Version { get; set; }

        public string LastChangeTime { get; set; }

        public int WaitMsec { get; set; }

        public string ExtractVersionFromAssemblyInfoCsFile { get; set; }

        public string ExtractVersionFromAssemblyFile { get; set; }

        #endregion

        #region Public Methods

        public override bool Execute()
        {
            // unhandled exceptions are logged by ms build.
            MsBuildSettings.MsBuildLog = Log;
            using (var controller = new MsBuildController())
            {
                var processingContext = new ProcessingContext
                    {
                        PredefinedProjectToProcess = Project,
                        Password = Password,
                        WaitMsec = WaitMsec,
                        ExtractVersionFromAssemblyInfoCsFile = ExtractVersionFromAssemblyInfoCsFile,
                        PredefinedSolutionFileToProcess = SolutionFile,
                        PredefinedAnswerForVersionRequestDialog = Version,
                        ExtractVersionFromAssemblyFile = ExtractVersionFromAssemblyFile,
                        UseReleaseConfiguration = UseReleaseConfiguration
                    };

                if (!string.IsNullOrEmpty(LastChangeTime))
                {
                    DateTime time;
                    if (!CommandHelper.ParseDateTime(LastChangeTime, out time))
                    {
                        throw new InvalidDataException("Cannot parse supplied time");
                    }
                    processingContext.LastChangeTime = time;
                }

                if (AnswerForFilterByDateStartTimeRequestDialogIsWeekAgo)
                {
                    processingContext.PredefinedDateTimeForDateFilterStartTimeRequestDialog =
                        DateTime.Today - new TimeSpan(7, 0, 0, 0);
                }

                var result = controller.Go(
                    processingContext,
                    x => { });

                if (result == Successfull.Yes)
                {
                    controller.SaveOptions();
                }

                return result == Successfull.Yes;
            }
        }

        #endregion
    }
}
