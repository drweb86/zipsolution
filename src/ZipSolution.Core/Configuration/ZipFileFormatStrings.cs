using System;

namespace ZipSolution.Core.Configuration
{
	public sealed class ZipFileFormatStrings
	{
		public string Debug { get; private set; }
		
		public string Release { get; private set; }
		
		public ZipFileFormatStrings(string debug, string release)
		{
			if (string.IsNullOrEmpty(debug))
			{
                throw new ArgumentNullException("debug");
			}
			
			if (string.IsNullOrEmpty(release))
			{
				throw new ArgumentNullException("release");
			}

            Debug = debug;
            Release = release;
		}
	}
}
