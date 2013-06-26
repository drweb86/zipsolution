using System;
using BULocalization;
using ZipSolution.Core.Filters;
using ZipSolution.Core.Tree.Nodes;

namespace ZipSolution.Core.Localization
{
    /// <summary>
    /// Converts filter action to string.
    /// </summary>
	public static class FilterActionConverter
	{
        public static string ToString(FilterAction action)
		{
			switch (action)
			{
				case FilterAction.ExcludeByMask:
                    return Translation.Current[46];

                case FilterAction.ExcludeByTime:
                    return Translation.Current[47];
					
				default:
					{
						throw new NotImplementedException(action.ToString());
					}
			}
		}
		
		public static string[] GetAllActions()
		{
            Array values = Kind.GetValues(typeof(FilterAction));
			string[] items = new string[values.Length];
			int i = 0;
            foreach (FilterAction item in values)
			{
				items[i] = ToString(item);
				i++;
			}
			
			return items;
		}

        public static FilterAction FromString(string actionToParse)
		{
			if (string.IsNullOrEmpty(actionToParse))
			{
				throw new ArgumentNullException("actionToParse");
			}

            if (actionToParse == Translation.Current[46])
			{
                return FilterAction.ExcludeByMask;
			}
            else if (actionToParse == Translation.Current[47])
			{
                return FilterAction.ExcludeByTime;
			}
			else
			{
				throw new NotImplementedException(actionToParse);
			}
		}
	}
}
