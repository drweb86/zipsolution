using System;
using System.IO;
using System.Globalization;
using ZipSolution.Core.Configuration;
using ZipSolution.Core.Controller;
using ZipSolution.Core.Tree.Nodes;
using ZipSolution.Core.View;

namespace ZipSolution.Core.Filters
{
    /// <summary>
    /// Exclude files by last write time filter.
    /// </summary>
	sealed class ExcludeFilesByTimeFilter: IFilter
	{
		private bool _inited;
		private bool _chooseTimeDialogShowed;
		private readonly FilterConfiguration _configuration;

		private DateTime? _date;

	    private bool _isEnabled;

		private bool match(DateTime time)
		{
			return (time >= _date);
		}

        public bool IsElementNameFilter
        {
            get { return false; }
        }

		public ExcludeFilesByTimeFilter(FilterConfiguration configuration)
		{
			if (configuration == null)
			{
				throw new ArgumentNullException("configuration");
			}

		    _isEnabled = true;
			_configuration = configuration;
			string date = _configuration.Parameter.Trim();
			if (!string.IsNullOrEmpty(date))
			{
				_date = DateTime.Parse(date, CultureInfo.CurrentCulture);
			}
		}

        bool IFilter.Init(ProcessingContext context)
		{
#warning: code review: form must be out of this place
			if (_isEnabled)
			{
				if (!_chooseTimeDialogShowed)
				{
					_chooseTimeDialogShowed = true;

                    if (context.PredefinedDateTimeForDateFilterStartTimeRequestDialog.HasValue)
					{
                        _date = context.PredefinedDateTimeForDateFilterStartTimeRequestDialog.Value;
						_configuration.Parameter = _date.ToString();
                        _inited = true;
					}
                    else if (context.LastChangeTime != default(DateTime))
                    {
                        _date = context.LastChangeTime;
                        _configuration.Parameter = _date.ToString();
                        _inited = true;
                    }
                    else
					{
                        using (var form = CommonController.Instance.CreateView<IGetLastModificationsView>())
						{
						    form.Init(_date.HasValue ? _date.Value : DateTime.Now, CommonController.Instance.Model.LastModificationsDialogTimeFormatString);
                            form.Process();

                            switch (form.Result)
                            { 
                                case GetLastModifications.Cancel:
                                    _inited = false;
                                    return false;

                                case GetLastModifications.DoNotUse:
                                    _isEnabled = false;
                                    _inited = true;
                                    return true;

                                case GetLastModifications.Ok:
                                    _date = form.ChosenTime;
								    _configuration.Parameter = _date.ToString();
                                    _inited = true;
                                    return true;
                                default:
                                    throw new NotSupportedException(form.Result.ToString());
                            }
						}
					}
				}
			}
			
			return true;
		}
		
		void IFilter.Apply(Element element)
		{
			if (!_inited)
			{
				throw new InvalidOperationException("ExcludeFilesByTimeFilter not inited");
			}

            if (_isEnabled &&
                element != null &&
                element.Kind == Kind.File)
            {
                var fileInfo = new FileInfo(element.FullName);

                if (!match(fileInfo.CreationTime))
                {
                    if (!match(fileInfo.LastWriteTime))
                    {
                        element.CheckStatus = ElementStatus.Exclude;
                    }
                }
            }
		}
	}
}
