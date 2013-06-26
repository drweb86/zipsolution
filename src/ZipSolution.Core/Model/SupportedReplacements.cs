using ZipSolution.Core.Commands.Hg;

namespace ZipSolution.Core.Model
{
    /// <summary>
    /// Supported replacement.
    /// </summary>
    public class SupportedReplacements
    {
        #region Common

        public const string Date = "$DATE";
        public const string Increment = "$INCREMENT";
        public const string Version = "$VERSION";

        #endregion

        #region Tortoise SVN Integration

        public const string TortoiseSvnRevision = "$TORTOISE_SVN_REVISION";

        public static bool HasTortoiseSvnIntegration(string suspected)
        {
            return suspected.ContainsCaseInsensitive(TortoiseSvnRevision);
        }

        public static string ResolveTortoiseSvnIntegration(string suspected, string tortoiseSvnRevision)
        {
            return suspected.ReplaceStringCaseInsensitive(TortoiseSvnRevision, tortoiseSvnRevision);
        }

        #endregion

        #region HG Integration

        public const string HgBranch = "$HG_BRANCH";
        public const string HgRevision = "$HG_REVISION";
        public const string HgNodeShort = "$HG_NODESHORT";
        public const string HgNodeFull = "$HG_NODEFULL";

        public static bool HasHgIntegration(string suspected)
        {
            return suspected.ContainsCaseInsensitive(HgBranch) ||
                suspected.ContainsCaseInsensitive(HgRevision) ||
                suspected.ContainsCaseInsensitive(HgNodeShort) ||
                suspected.ContainsCaseInsensitive(HgNodeFull);
        }

        public static string ResolveHgIntegration(string suspected, HgInfo hgInfo)
        {
            return suspected
                .ReplaceStringCaseInsensitive(HgBranch, hgInfo.Branch)
                .ReplaceStringCaseInsensitive(HgNodeFull, hgInfo.NodeFull)
                .ReplaceStringCaseInsensitive(HgNodeShort, hgInfo.NodeShort)
                .ReplaceStringCaseInsensitive(HgRevision, hgInfo.Revision);
        }

        #endregion

        #region Methods

        

        #endregion
    }
}
