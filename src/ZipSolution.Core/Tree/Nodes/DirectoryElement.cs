namespace ZipSolution.Core.Tree.Nodes
{
    /// <summary>
    /// Directory element.
    /// </summary>
	public sealed class DirectoryElement: Element
    {
        #region Properties

        public override Kind Kind
		{
            get { return Kind.Folder; }
		}

        #endregion

        #region Constructors

        public DirectoryElement(string folder)
			: base(folder)
		{
        }

        #endregion
    }
}
