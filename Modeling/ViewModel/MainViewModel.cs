using System;
using System.Collections.Generic;
using Levshits.Wpf.Common.ViewModel;
using Modeling.Command;
using Modeling.Logic;
using Modeling.Model;
using OxyPlot;
using OxyPlot.Axes;

namespace Modeling.ViewModel
{
    /// <summary>
    ///     Class MainViewModel.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private string _additionalInfo;
        private PlotModel _chart;
        private Guid _generatorId;
        private InitialParametersBase _initialParametetersModel;
        public ComputeCommand ComputeCommand { get; set; }

        public InitialParametersBase InitialParameters
        {
            get { return _initialParametetersModel; }
            set
            {
                _initialParametetersModel = value;
                OnPropertyChanged();
            }
        }

        public GeneratorHelper GeneratorHelper { get; set; }


        public string AdditionalInfo
        {
            get { return _additionalInfo; }
            set
            {
                _additionalInfo = value;
                OnPropertyChanged();
            }
        }

        public Dictionary<Guid, string> Generators => GeneratorHelper.Generators;

        public PlotModel Chart
        {
            get { return _chart; }
            set
            {
                _chart = value;
                OnPropertyChanged();
            }
        }

        public Guid GeneratorId
        {
            get { return _generatorId; }
            set
            {
                _generatorId = value;
                OnPropertyChanged();
                InitialParameters = GeneratorHelper.GetInitialParametersBase(_generatorId);
                AdditionalInfo = String.Empty;
                Chart = new PlotModel();
            }
        }

        public MainViewModel()
        {
            Chart = new PlotModel();
            Chart.Axes.Add(new LinearAxis {Position = AxisPosition.Left});
            Chart.Axes.Add(new CategoryAxis {Position = AxisPosition.Bottom});
        }
    }
}