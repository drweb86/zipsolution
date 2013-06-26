using System;
using System.Globalization;

namespace ZipSolution.Core.Commands
{
    /// <summary>
    /// Contains common command functional.
    /// </summary>
    public static class CommandHelper
    {
        public static bool ParseDateTime(string parse, out DateTime result)
        {
            DateTime parsedTime;
            if (DateTime.TryParse(parse, CultureInfo.GetCultureInfo("En-Us"), DateTimeStyles.AllowInnerWhite | DateTimeStyles.AllowLeadingWhite | DateTimeStyles.AllowTrailingWhite | DateTimeStyles.AllowWhiteSpaces, out parsedTime))
            {
                result = parsedTime;
                return true;
            }

            result = DateTime.MinValue;
            return false;
        }
    }
}
