using System;
using System.IO;
using System.Security;
using BULocalization;
using ZipSolution.Core.Configuration;
using ZipSolution.Core.Controller;

namespace ZipSolution.Core.Commands
{
    /// <summary>
    /// Loads solution from specified file.
    /// </summary>
    class LoadSolutionFromFileCommand
    {
        #region Public Methods

        public ZipSolutionEntry LoadSolutionFromFile(CommonController context, string file)
        {
            if (string.IsNullOrEmpty(file))
            {
                throw new ArgumentNullException("file");
            }

            if (!Path.IsPathRooted(file))
            {
                file = new FileInfo(file).FullName;
            }

            try
            {
                return XmlSettingsRepresentation.LoadSolution(context.Log, file);
            }
            catch (NullReferenceException e)
            {
                context.ShowErrorBox(Translation.Current[78], e.Message);
                return null;
            }
            catch (SecurityException e)
            {
                context.ShowErrorBox(Translation.Current[78], e.Message);
                return null;
            }
            catch (IOException e)
            {
                context.ShowErrorBox(Translation.Current[78], e.Message);
                return null;
            }
            catch (Exception e)
            {
                context.ProcessErrors(e.ToString());
                return null;
            }
        }

        #endregion
    }
}
