using System;
using ZipSolution.Core.Tree.Nodes;

namespace ZipSolution.Core.Filters
{
    /// <summary>
    /// Exclude files by mask filter.
    /// </summary>
	public sealed class ExcludeFilesByMaskFilter: IFilter
	{
		private readonly string _regEx;

        public bool IsElementNameFilter
        {
            get { return true; }
        }

		public ExcludeFilesByMaskFilter(string mask)
		{
			if (string.IsNullOrEmpty(mask))
			{
				throw new ArgumentNullException("mask");
			}
			
			_regEx = FilterUtil.ConvertMaskToRegEx(mask);
		}

        bool IFilter.Init(ProcessingContext context)
		{
			return true;
		}
		
		void IFilter.Apply(Element element)
		{
			if (element != null)
			{
				if (element.Kind == Kind.File)
				{
					if (FilterUtil.CheckIfMatch(element.Name, _regEx))
					{
						element.CheckStatus = ElementStatus.Exclude;
					}
				}
			}
		}
	}
}
