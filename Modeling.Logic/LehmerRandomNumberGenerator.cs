using System.Collections.Generic;
using System.Linq;
using Modeling.Common;

namespace Modeling.Logic
{
    /// <summary>
    /// Class LehmerRandomNumberGenerator.
    /// Implement generator using Lehmer formula
    /// </summary>
    public class LehmerRandomNumberGenerator : IPeriodicNumberGenerator
    {
        #region fields

        private int? _shift;
        private int? _period;

        #endregion fields

        #region properties

        public int M { get; set; }
        public int A { get; set; }
        public int R { get; set; }

        #endregion properties

        #region .ctor

        public LehmerRandomNumberGenerator()
        {
        }

        public LehmerRandomNumberGenerator(int a, int m, int r)
        {
            A = a;
            M = m;
            R = r;
        }

        #endregion .ctor

        public double Next()
        {
            R = (A * R) % M;
            return (double)R / M;
        }

        public void Reset()
        {
            R = 0;
            _period = null;
            _shift = null;
        }

        private void ComputeGeneratorParameters()
        {
            
            var r = R;
            var a = A;
            var m = M;
            var testdata = new List<int>();
            for (int i = 0; i < m; i++)
            {
                r = (a * r) % m;
            }
            var testValue = r;
            r = R;
            a = A;
            m = M;
            var index = 0;
            while (testdata.Count<2)
            {
                index++;
                r = (a * r) % m;
                if (testValue == r)
                {
                    testdata.Add(index);
                }
            }
            _period = testdata[1] - testdata[0];
            _shift = m%_period + _period;
        }

        public int? GetPeriod()
        {
            if (!_period.HasValue)
            {
                ComputeGeneratorParameters();
            }
            return _period;
        }

        public int? GetShift()
        {
            if (!_shift.HasValue)
            {
                ComputeGeneratorParameters();
            }
            return _shift;
        }

        public void Dispose()
        {
            Reset();
        }
    }
}
