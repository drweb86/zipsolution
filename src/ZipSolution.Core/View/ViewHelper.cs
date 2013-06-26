using System.IO;
using ZipSolution.Core.Commands.Hg;
using ZipSolution.Core.Model;

namespace ZipSolution.Core.View
{
    /// <summary>
    /// Contains view methods.
    /// </summary>
    public static class ViewHelper
    {
        /// <summary>
        /// Gets first illegal character.
        /// </summary>
        /// <param name="file">File name excluding it's path</param>
        /// <param name="firstIllegalCharacter"></param>
        /// <returns>true - if it contains illegal characters</returns>
        public static bool CheckFilenameForIllegalCharacters(string file, out char firstIllegalCharacter)
        {
            firstIllegalCharacter = ' ';

            file = file.ReplaceStringCaseInsensitive(SupportedReplacements.Date, "X");
            file = SupportedReplacements.ResolveTortoiseSvnIntegration(file, "X");
            file = SupportedReplacements.ResolveHgIntegration(file, new HgInfo("X", "X", "X", "X"));
            file = file.ReplaceStringCaseInsensitive(SupportedReplacements.Version, "X");
            file = file.ReplaceStringCaseInsensitive(SupportedReplacements.Increment, "X");

            int index = file.IndexOfAny(Path.GetInvalidFileNameChars());

            if (index > -1)
            {
                firstIllegalCharacter = file[index];
            }

            return index > -1;
        }
    }
}
