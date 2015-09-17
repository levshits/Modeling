using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Modeling.Logic;
using Modeling.ViewModel;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace Modeling.Command
{
    public class ComputeCommand: ICommand
    {
        public MainViewModel ViewModel { get; set; }
        public LehmerRandomNumberGenerator LehmerGenerator { get; set; }
        public bool CanExecute(object parameter)
        {
            return ViewModel.InitialParametersModel.M > 0 && ViewModel.InitialParametersModel.A > 1 &&
            ViewModel.InitialParametersModel.InitialValue >= 1;
        }

        public void Execute(object parameter)
        {
            LehmerGenerator.Reset();
            LehmerGenerator.M = ViewModel.InitialParametersModel.M;
            LehmerGenerator.A = ViewModel.InitialParametersModel.A;
            LehmerGenerator.R = ViewModel.InitialParametersModel.InitialValue;
            var values = new List<double>();
            for (int i = 0; i < 100000; i++)
            {
                values.Add(LehmerGenerator.Next());
            }
            var minValue = values.Min();
            var maxValue = values.Max();
            var delta = (maxValue - minValue)/20;
            var axis = new CategoryAxis() {Position = AxisPosition.Bottom};
            for (int i = 0; i < 20; i++)
            {
                axis.Labels.Add($"{Math.Round(minValue+delta*i, 2)}-{Math.Round(minValue + delta * (i+1), 2)}");
            }
            ViewModel.Chart.Axes.Clear();
            ViewModel.Chart.Axes.Add(axis);
            ViewModel.Chart.Axes.Add(new LinearAxis());

            LehmerGenerator.Reset();
            LehmerGenerator.M = ViewModel.InitialParametersModel.M;
            LehmerGenerator.A = ViewModel.InitialParametersModel.A;
            LehmerGenerator.R = ViewModel.InitialParametersModel.InitialValue;
            ViewModel.AdditionalInfo =
                string.Format("Mx: {0}\n Dx: {1}\n Sigma: {2}\n Period: {3}\n Aperiodic part: {4}\n R: {5}",
                    Math.Round(GeneratorAnalyserHelper.GetMathExpected(values),3), Math.Round(GeneratorAnalyserHelper.GetDispersion(values),3),
                    Math.Round(GeneratorAnalyserHelper.GetStandartDeviation(values), 3), LehmerGenerator.GetPeriod(),
                    LehmerGenerator.GetShift(),
                    Math.Round(GeneratorAnalyserHelper.GetSequenceParameters(values),3));
            ViewModel.Chart.Series.Clear();
            var columnSeries = new ColumnSeries();
            for (int i = 0; i < 20; i++)
            {
                var itemsCount = values.Count(x => x > (minValue + i*delta) && x < (minValue + (i + 1)*delta));
                columnSeries.Items.Add(new ColumnItem(((double)itemsCount/values.Count)));
            }
            ViewModel.Chart.Series.Add(columnSeries);
            ViewModel.Chart.InvalidatePlot(true);

        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
