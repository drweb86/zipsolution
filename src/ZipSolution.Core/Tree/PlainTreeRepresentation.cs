namespace ZipSolution.Core.Tree
{
    /// <summary>
    /// Represents a node representation as 
    /// </summary>
    public sealed class PlainTreeRepresentation
    {
        /// <summary>
        /// File or folder to bind
        /// </summary>
        public string Target { get; set; }

        /// <summary>
        /// Relative path in an archive
        /// </summary>
        public string RelativeFolderInArchive { get; set; }
    }
}
