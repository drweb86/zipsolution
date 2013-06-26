using System;
using BULocalization;
using ZipSolution.Core.Tree.Nodes;

namespace ZipSolution.Core.Localization
{
    /// <summary>
    /// Converts kind enum to localized string.
    /// </summary>
    public static class KindConverter
	{
		public static string ToString(Kind kind)
		{
			switch (kind)
			{
				case Kind.File:
                    return Translation.Current[44];
				
				case Kind.Folder:
                    return Translation.Current[45];
			
				default:
					{
						throw new NotImplementedException(kind.ToString());
					}
			}
		}
		
		public static string[] GetAllKinds()
		{
			Array values = Kind.GetValues(typeof(Kind));
			string[] items = new string[values.Length];
			int i = 0;
			foreach (Kind item in values)
			{
				items[i] = ToString(item);
				i++;
			}
			
			return items;
		}
		
		public static Kind FromString(string name)
		{
            if (name == Translation.Current[44])
			{
				return Kind.File;
			}
            else if (name == Translation.Current[45])
			{
				return Kind.Folder;
			}
			else
			{
				throw new NotImplementedException(name);
			}
		}
	}
}
