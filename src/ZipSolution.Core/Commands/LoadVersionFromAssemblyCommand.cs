using System;
using System.Diagnostics;
using System.IO;
using HDE.Platform.FileIO;
using ZipSolution.Core.Controller;

namespace ZipSolution.Core.Commands
{
    /// <summary>
    /// Loads version from assemblyinfo file.
    /// </summary>
    class LoadVersionFromAssemblyCommand
    {
        #region Public Methods

        public string LoadVersionFromAssembly(CommonController context, string assemblyRelativePath)
        {
            string resolvedFile = assemblyRelativePath;
            try
            {
                resolvedFile = RelativePathDiscovery.ResolveRelativePath(resolvedFile, Directory.GetCurrentDirectory());
                return FileVersionInfo.GetVersionInfo(resolvedFile).FileVersion;
            }
            catch (Exception e)
            {
                context.ShowErrorBox("{0}: {1}", resolvedFile, e.Message);
                throw;
            }
        }

        #endregion
    }
}
