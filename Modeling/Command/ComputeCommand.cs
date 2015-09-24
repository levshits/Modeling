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
        public GeneratorHelper GeneratorHelper { get; set; }

        public bool CanExecute(object parameter)
        {
            return ViewModel.InitialParameters != null && ViewModel.InitialParameters.IsValid;
        }

        public void Execute(object parameter)
        {
            var generator = GeneratorHelper.GetGenerator(ViewModel.GeneratorId);
            generator.Init(ViewModel.InitialParameters);
            ViewModel.Chart = generator.GetPlotModel(20, 100000);

            var values = new List<double>();
            for (int i = 0; i < 100000; i++)
            {
                values.Add(generator.Next());
            }
            generator.Reset();

            ViewModel.AdditionalInfo =
                $" Mx: {Math.Round(GeneratorAnalyserHelper.GetMathExpected(values), 3)}\n Dx: {Math.Round(GeneratorAnalyserHelper.GetDispersion(values), 3)}\n Sigma: {Math.Round(GeneratorAnalyserHelper.GetStandartDeviation(values), 3)}\n R: {Math.Round(GeneratorAnalyserHelper.GetSequenceParameters(values), 3)}";
            if (generator is LehmerRandomNumberGenerator)
            {
                ViewModel.AdditionalInfo = ViewModel.AdditionalInfo +
                                           $"\n Aperiodic part: {((LehmerRandomNumberGenerator)generator).GetShift()}\n Period: {((LehmerRandomNumberGenerator)generator).GetPeriod()}\n";
            }

        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
