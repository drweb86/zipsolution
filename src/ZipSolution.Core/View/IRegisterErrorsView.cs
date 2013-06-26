using HDE.Platform.AspectOrientedFramework;
using ZipSolution.Core.Model;

namespace ZipSolution.Core.View
{
    /// <summary>
    /// Registers errors view.
    /// </summary>
    public interface IRegisterErrorsView : IBaseView<BaseController<CommonModel>>
    {
        void Init(string errorMessage);
    }
}
