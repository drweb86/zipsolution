using System;
using ZipSolution.Core.Tree.Nodes;

namespace ZipSolution.Core.Filters
{
    /// <summary>
    /// Configuration of filter.
    /// </summary>
#warning: extract factory class.
    public sealed class FilterConfiguration
	{
		public Kind Affected { get; private set; }
		
		public FilterAction FilterAction { get; private set; }
		
		public string Parameter { get; set; }
		
		public FilterConfiguration(Kind affected, FilterAction filterAction, string parameter)
		{
			if (string.IsNullOrEmpty(parameter))
			{
				throw new ArgumentNullException("parameter");
			}

            Affected = affected;
            FilterAction = filterAction;
			Parameter = parameter;
		}
		
		public IFilter CreateFilter()
		{
            if (Affected == Kind.File)
			{
                switch (FilterAction)
				{
					case FilterAction.ExcludeByMask:
                        return new ExcludeFilesByMaskFilter(Parameter);
						
					case FilterAction.ExcludeByTime:
                        return new ExcludeFilesByTimeFilter(this);
				}
			}
			else
			{
                switch (FilterAction)
				{
					case FilterAction.ExcludeByMask:
                        return new ExcludeFoldersByMaskFilter(Parameter);
				}
			}

            throw new InvalidOperationException(string.Format("{0}:{1}", Affected, FilterAction));
		}
	}
}
