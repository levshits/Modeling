using System;
using System.Collections.Generic;
using System.Linq;

namespace Modeling.Logic
{
    public class GeneratorAnalyserHelper
    {
        public static double GetMathExpected(List<double> values)
        {
            if (values.Count==0)
            {
                throw new ArgumentException();
            }
            return values.Sum()/values.Count;
        }

        public static double GetDispersion(List<double> values, double mx )
        {
            return GetMathExpected(values.Select(x => (x - mx)*(x- mx)).ToList());
        }
        public static double GetDispersion(List<double> values)
        {
            var mx = GetMathExpected(values);
            return GetMathExpected(values.Select(x => (x - mx) * (x - mx)).ToList());
        }

        public static double GetStandartDeviation(double dx)
        {
            return Math.Sqrt(dx);
        }

        public static double GetStandartDeviation(List<double> values)
        {
            return GetStandartDeviation(GetDispersion(values));
        }

        public static double GetSequenceParameters(List<double> values)
        {
            var k = 0;
            for (int i = 0; i < values.Count/2; i++)
            {
                if ((values[i]*values[i] + values[i + 1]*values[i + 1]) < 1)
                {
                    k++;
                }
            }
        }
    }
}