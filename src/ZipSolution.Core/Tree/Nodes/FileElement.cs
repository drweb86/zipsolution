namespace ZipSolution.Core.Tree.Nodes
{
    /// <summary>
    /// File element.
    /// </summary>
    public sealed class FileElement : Element
    {
        #region Properties

        public override Kind Kind
		{
            get { return Kind.File; }
		}

        #endregion

        #region Constructors

        public FileElement(string file)
			:base(file)
		{
        }

        #endregion
    }
}
