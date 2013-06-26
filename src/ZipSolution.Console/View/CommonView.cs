using HDE.Platform.AspectOrientedFramework;
using ZipSolution.Core.Controller;
using ZipSolution.Core.Model;

namespace ZipSolution.Console.View
{
    abstract class CommonView : IBaseView<BaseController<CommonModel>>
    {
        public virtual void Dispose()
        {
            
        }

        protected CommonController Context { get; private set; }
        public void SetContext(BaseController<CommonModel> context)
        {
            Context = (CommonController)context;
        }
        
        public abstract bool Process();
    }
}
