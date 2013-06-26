using System;
using System.Globalization;
using System.IO;
using HDE.Platform.Logging;

namespace ZipSolution.Core.Misc
{
    /// <summary>
    /// Represents ZipSolution file log.
    /// </summary>
    public class ZipSolutionFileLog : HtmlLog
    {
        #region Constants

        private const string _htmlOpen =
@"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">
<HTML>
<HEAD>
	<META HTTP-EQUIV=""CONTENT-TYPE"" CONTENT=""text/html; charset=utf-8"">
	<TITLE>{0}-{1}</TITLE>
	<META NAME=""GENERATOR"" CONTENT=""ZipSolution File Log"">
</HEAD>
<BODY>
<table border=""0"" align=""center"" cellpadding=""5"" cellspacing=""0"" width=""100%"">
	<tr>
		<td align=""center"" nowrap=""nowrap"" bgcolor=""#264b99"">
			<a target=""_new"" href=""{2}""><font color=""#ffffff"">{5}</font></a>
			<a target=""_new"" href=""{3}""><font color=""#ffffff"">{6}</font></a>
			<a target=""_new"" href=""{4}""><font color=""#ffffff"">{7}</font></a>
		</td>
	</tr>
<table>
</br>";

        #endregion

        #region Constructors

        public ZipSolutionFileLog() :
            base(Path.Combine(Path.GetTempPath(), @"HDE\ZipSolution"),
            getHtmlOpenFileLog())
        {
        }

        #endregion

        #region Private Methods

        static string getHtmlOpenFileLog()
        {
            return string.Format(
                CultureInfo.CurrentCulture,
                _htmlOpen,
                DateTime.Now.ToString("f"),
                "Log",
                "http://zipsolution.codeplex.com/",
                "http://zipsolution.codeplex.com/workitem/list/basic",
                "http://zipsolution.codeplex.com/discussions",
                "Visit Home Page",
                "Report Bug",
                "Discuss");
        }

        #endregion
    }
}
