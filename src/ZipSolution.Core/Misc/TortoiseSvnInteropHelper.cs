using System;
using System.IO;
using System.Globalization;
using System.Text;

namespace ZipSolution.Core.Misc
{
	/// <summary>
	/// Interoping with tortoiseSvn on data
	/// </summary>
	/// <remarks>User should commit changes begore and _update_ directoryUnderSvn before using it</remarks>
	public static class TortoiseSvnInteropHelper
	{
		private const string _FolderIsNotUnderSvn = "Folder is not under svn: file '{0}' does not exist";

		/// <summary>
		/// Extracts revision
		/// </summary>
		/// <param name="directoryUnderSvn"></param>
		/// <exception cref="InvalidOperationException">Directory is not under svn</exception>
		/// <returns>Revision</returns>
		public static string ExtractRevision(string directoryUnderSvn)
		{
			if (string.IsNullOrEmpty(directoryUnderSvn))
			{
				throw new ArgumentNullException("directoryUnderSvn");
			}
			
			string file = Path.Combine(directoryUnderSvn, @".svn\entries");
			if (!File.Exists(file))
			{
				throw new InvalidOperationException(
                    string.Format(
                        CultureInfo.CurrentCulture, 
                        _FolderIsNotUnderSvn, 
                        file));
			}
			
			string fileContent = File.ReadAllText(file);
			var revision = new StringBuilder();
			foreach (var character in fileContent)
			{
				if ( (character >= '0') && (character <= '9') )
				{
					revision.Append(character);
				}
				else
				{
					break;
				}
			}
			return revision.ToString();
		}
	}
}