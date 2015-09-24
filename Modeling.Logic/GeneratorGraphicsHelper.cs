using System;
using System.Collections.Generic;
using System.Linq;
using Modeling.Common;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace Modeling.Logic
{
    public static class GeneratorGraphicsHelper
    {
        public static PlotModel GetPlotModel(this IRandomNumberGenerator generator, int columnCount,
            int experimentsCount)
        {
            var plotModel = new PlotModel();
            var values = new List<double>();
            for (var i = 0; i < experimentsCount; i++)
            {
                values.Add(generator.Next());
            }
            var minValue = values.Min()*0.999;
            var maxValue = values.Max()*1.001;
            var delta = (maxValue - minValue)/columnCount;
            var axis = new CategoryAxis {Position = AxisPosition.Bottom};
            for (var i = 0; i < columnCount; i++)
            {
                axis.Labels.Add($"{Math.Round(minValue + delta*i, 2)}-{Math.Round(minValue + delta*(i + 1), 2)}");
            }
            plotModel.Axes.Clear();
            plotModel.Axes.Add(axis);
            plotModel.Axes.Add(new LinearAxis());

            var columnSeries = new ColumnSeries();
            for (var i = 0; i < columnCount; i++)
            {
                var itemsCount = values.Count(x => x > (minValue + i*delta) && x < (minValue + (i + 1)*delta));
                columnSeries.Items.Add(new ColumnItem(((double) itemsCount/values.Count)));
            }
            plotModel.Series.Add(columnSeries);
            return plotModel;
        }
    }
}
