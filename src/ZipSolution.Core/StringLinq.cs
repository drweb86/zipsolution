using System;
using System.Text;

namespace ZipSolution.Core
{
    public static class StringLinq
    {
        // thanks to C. Dragon 76, http://stackoverflow.com/users/5682/c-dragon-76
        public static string ReplaceStringCaseInsensitive(this string str, string oldValue, string newValue)
        {
            var sb = new StringBuilder();

            int previousIndex = 0;
            int index = str.IndexOf(oldValue, StringComparison.OrdinalIgnoreCase);
            while (index != -1)
            {
                sb.Append(str.Substring(previousIndex, index - previousIndex));
                sb.Append(newValue);
                index += oldValue.Length;

                previousIndex = index;
                index = str.IndexOf(oldValue, index, StringComparison.OrdinalIgnoreCase);
            }
            sb.Append(str.Substring(previousIndex));

            return sb.ToString();
        }

        public static bool ContainsCaseInsensitive(this string str, string oldValue)
        {
            return str.ToLowerInvariant().Contains(oldValue.ToLowerInvariant());
        }
    }
}
