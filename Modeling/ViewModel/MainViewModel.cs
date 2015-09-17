using Levshits.Wpf.Common.ViewModel;
using Modeling.Command;
using Modeling.Model;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;


namespace Modeling.ViewModel
{
    /// <summary>
    /// Class MainViewModel.
    /// </summary>
    public class MainViewModel: ViewModelBase
    {
        private string _additionalInfo;
        private PlotModel _chart;
        public ComputeCommand ComputeCommand { get; set; }
        public InitialParametersModel InitialParametersModel { get; set; }

        public string AdditionalInfo
        {
            get
            {
                return _additionalInfo;
            }
            set
            {
                _additionalInfo = value;
                OnPropertyChanged();
            }
        }

        public PlotModel Chart
        {
            get
            {
                return _chart;
            }
            set
            {
                _chart = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            InitialParametersModel = new InitialParametersModel();
            Chart = new PlotModel();
            Chart.Axes.Add(new LinearAxis() {Position = AxisPosition.Left});
            Chart.Axes.Add(new CategoryAxis() {Position = AxisPosition.Bottom});
        }


    }
}