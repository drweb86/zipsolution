using System;
using HDE.Platform.AspectOrientedFramework;
using ZipSolution.Core.Model;

namespace ZipSolution.Core.View
{
    /// <summary>
    /// Gets last modifications view.
    /// </summary>
    public interface IGetLastModificationsView : IBaseView<BaseController<CommonModel>>
    {
        DateTime ChosenTime { get; }
        GetLastModifications Result { get; }
        void Init(DateTime previousTime, string lastModificationsDialogTimeFormatString);
    }

    public enum GetLastModifications
    {
        DoNotUse,
        Ok,
        Cancel
    }
}
