using System;
using System.IO;
using BULocalization;
using HDE.Platform.Logging;
using ZipSolution.Core.Commands;
using ZipSolution.Core.View;

namespace ZipSolution.Console.View
{
    class GetLastModificationsView : CommonView, IGetLastModificationsView
    {
        #region Fields

        private DateTime _previousTime;

        #endregion

        #region Properties

        public DateTime ChosenTime { get; private set; }

        public GetLastModifications Result { get; private set; }

        #endregion

        #region Public Methods

        public override bool Process()
        {
            Context.Log.Debug(Translation.Current[83], _previousTime.ToString(Context.Model.LastModificationsDialogTimeFormatString));

            var time = System.Console.ReadLine();
            Context.Log.Debug (Translation.Current[84], time);
            if (string.IsNullOrWhiteSpace(time))
            {
                Result = GetLastModifications.DoNotUse;
            }
            else if (string.Compare(time, "p", StringComparison.OrdinalIgnoreCase)==0)
            {
                ChosenTime = _previousTime;
                Result = GetLastModifications.Ok;
            }
            else
            {
                DateTime parsedTime;
                if (CommandHelper.ParseDateTime(time, out parsedTime))
                {
                    ChosenTime = parsedTime;
                    Result = GetLastModifications.Ok;
                }
                else
                {
                    Context.Log.Error( Translation.Current[85]);
                    throw new InvalidDataException(Translation.Current[85]);
                }
            }
            return true;
        }

        public void Init(DateTime previousTime, string lastModificationsDialogTimeFormatString)
        {
            _previousTime = previousTime;
        }

        #endregion
    }
}
