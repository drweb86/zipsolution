using System;
using System.Diagnostics;
using System.Threading;

namespace ZipSolution.Commands
{
    /// <summary>
    /// Opens folder in Explorer.
    /// </summary>
    class OpenFolderInShellCommand
    {
        public void OpenFolderInShell(Controller controller, string folder)
        {
            if (string.IsNullOrEmpty(folder))
            {
                throw new ArgumentNullException("folder");
            }

            ThreadPool.QueueUserWorkItem(openInShellQueueItem, new Tuple<Controller, string>(controller, folder));
        }

        #region Private Methods

        private static void openInShellQueueItem(object args)
        {
            var typedArgs = (Tuple<Controller, string>) args;
            var process = new Process 
            {
                StartInfo =
                    {
                        UseShellExecute = true, 
                        FileName = typedArgs.Item2
                    }
            };

            try
            {
                process.Start();
            }
            catch (InvalidOperationException e)
            {
                typedArgs.Item1.ShowErrorBox(e.Message);
            }
            //System.ComponentModel.Win32Exception replaced on Exception for portability
            catch (Exception e)
            {
                typedArgs.Item1.ShowErrorBox(e.Message);
            }
        }

        #endregion
    }
}
