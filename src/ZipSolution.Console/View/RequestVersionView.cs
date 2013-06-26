using BULocalization;
using ZipSolution.Core.View;

namespace ZipSolution.Console.View
{
    class RequestVersionView :CommonView, IRequestVersionView
    {
        #region Properties

        public string Version { get; private set; }

        #endregion

        #region Public Methods

        public override bool Process()
        {
            Context.Log.Debug(Translation.Current[86], Version);
            var version = System.Console.ReadLine();

            Context.Log.Debug(Translation.Current[84], version);
            if (!string.IsNullOrEmpty(version))
            {
                Version = version;
            }

            char illegal;
            if (ViewHelper.CheckFilenameForIllegalCharacters(Version, out illegal))
            {
                Context.Log.Error (Translation.Current[87], illegal);
                return false;
            }

            return true;
        }

        public void Init(string previousVersion)
        {
            Version = previousVersion.Trim();
        }

        #endregion
    }
}
