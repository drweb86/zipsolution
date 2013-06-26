using HDE.Platform.AspectOrientedFramework;
using ZipSolution.Core.DataSources;
using ZipSolution.Core.Model;

namespace ZipSolution.UI
{
    /// <summary>
    /// Chooses datasource type.
    /// </summary>
    interface IChooseDataSourceTypeView:IBaseView<BaseController<CommonModel>>
    {
        DataSourceEnum DataSourceType { get; }
    }
}