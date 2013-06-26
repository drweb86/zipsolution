namespace ZipSolution.Core.Commands.Hg
{
    public class HgInfo
    {
        #region Properties

        public string Branch { get; private set; }
        public string Revision { get; private set; }
        public string NodeShort { get; private set; }
        public string NodeFull { get; private set; }

        #endregion

        #region Constructors

        public HgInfo(string branch, string revision, string nodeShort, string nodeFull)
        {
            Branch = branch;
            Revision = revision;
            NodeShort = nodeShort;
            NodeFull = nodeFull;
        }

        #endregion
    }
}
