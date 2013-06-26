using ZipSolution.Core.Tree.Nodes;

namespace ZipSolution.Core.Filters
{
    /// <summary>
    /// IFilter element.
    /// </summary>
    public interface IFilter
	{
		void Apply(Element element);
		
		bool Init(ProcessingContext context);

        bool IsElementNameFilter { get; }
	}
}
