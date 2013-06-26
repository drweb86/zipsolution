using System;
using ZipSolution.Core.Tree.Nodes;

namespace ZipSolution.Core.Filters
{
    /// <summary>
    /// Exclude folders by mask filter.
    /// </summary>
    public sealed class ExcludeFoldersByMaskFilter : IFilter
	{
		private readonly string _regEx;

        public bool IsElementNameFilter 
        {
            get { return true; } 
        }

		public ExcludeFoldersByMaskFilter(string mask)
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
				if (element.Kind == Kind.Folder)
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
