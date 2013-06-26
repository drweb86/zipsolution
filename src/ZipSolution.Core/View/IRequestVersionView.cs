using HDE.Platform.AspectOrientedFramework;
using ZipSolution.Core.Model;

namespace ZipSolution.Core.View
{
    /// <summary>
    /// Requests version.
    /// </summary>
    public interface IRequestVersionView : IBaseView<BaseController<CommonModel>>
    {
        void Init(string previousVersion);
        string Version { get; }
    }
}
