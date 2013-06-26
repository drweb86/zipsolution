using System;
using System.IO;
using HDE.Platform.FileIO;
using ZipSolution.Core.Controller;

namespace ZipSolution.Core.Commands
{
    /// <summary>
    /// Loads version from AssemblyInfo.cs file.
    /// </summary>
    class LoadVersionFromAssemblyInfoCsCommand
    {
        #region Public Methods

        public string LoadVersionFromAssemblyInfoCs(CommonController context, string assemblyInfoCsFileRelativePath)
        {
            try
            {
                const string pattern = "AssemblyVersion(\"";
                string resolvedFile = RelativePathDiscovery.ResolveRelativePath(assemblyInfoCsFileRelativePath, Directory.GetCurrentDirectory());
                string[] data = File.ReadAllLines(resolvedFile);
                int posStart = -1;
                foreach (string text in data)
                {
                    // comments that VS 2010 produces for assemblyinfo.cs files skippage
                    if (text.StartsWith(@"//"))
                    {
                        continue;
                    }
                    posStart = text.IndexOf(pattern);
                    if (posStart != -1)
                    {
                        posStart += pattern.Length;

                        int posEnd = text.IndexOf("\"", posStart);

                        if (posEnd == -1)
                        {
                            throw new InvalidOperationException(string.Format("Could not find closing \" in file '{0}' after text 'AssemblyVersion(\"'", resolvedFile));
                        }

                        string version = text.Substring(posStart, posEnd - posStart);

                        return  version.Replace("*", "x");
                    }

                }
                
                throw new InvalidOperationException(string.Format("File '{0}' does not contain occurence of string 'AssemblyVersion(\"'", resolvedFile));
            }
            catch (InvalidOperationException e)
            {
                context.ShowErrorBox(e.Message);
                throw;
            }
            catch (FileNotFoundException e)
            {
                context.ShowErrorBox(string.Format("{0}: {1}", assemblyInfoCsFileRelativePath, e.Message));
                throw;
            }

        }

        #endregion
    }
}
