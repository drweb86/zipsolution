using ZipSolution.Core.View;

namespace ZipSolution.Console.View
{
    class RegisteredErrorsView : CommonView, IRegisterErrorsView
    {
        public override bool Process()
        {
            return true;
        }

        public void Init(string errorMessage)
        {
            // error is logged just before showing view. So user already saw it.
        }
    }
}
