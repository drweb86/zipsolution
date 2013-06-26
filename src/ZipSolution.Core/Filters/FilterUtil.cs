using System.Text.RegularExpressions;

namespace ZipSolution.Core.Filters
{
    /// <summary>
    /// Contains various filter helper functional.
    /// </summary>
    public static class FilterUtil
	{
        public static string ConvertMaskToRegEx(string mask)
		{
			return Regex.Escape(mask).Replace(@"\*", ".*").Replace(@"\?",".");
		}
		
		public static bool CheckIfMatch(string someString, string regEx)
		{
		    var captures = Regex.Match(someString, regEx).Captures;
		    int stringLen = someString.Length;
            foreach (Capture capture in captures)
            {
                if (stringLen == capture.Length)
                {
                    return true;
                }
            }
		    return false;
		}
	}
}
