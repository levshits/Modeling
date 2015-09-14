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

        private readonly List<int> _generatedValues = new List<int>();
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

        public bool MoveNext()
        {
            R = (A * R) % M;


            if (_generatedValues.Any(x => x == R) && !_shift.HasValue)
            {
                _shift = _generatedValues.IndexOf(R) + 1;
                _period = _generatedValues.Count - _shift;
            }

            var hasNext = !IsStopOnCycleDetectionEnabled || _generatedValues.All(x => x != R);
            if (hasNext)
            {
                _generatedValues.Add(R);
            }
            return hasNext;
        }

        public void Reset()
        {
            _generatedValues.Clear();
            _period = null;
            _shift = null;
        }

        double IEnumerator<double>.Current => (double)Current;

        public object Current => (double)_generatedValues.Last() / M;

        public bool IsStopOnCycleDetectionEnabled { get; set; }

        public int? GetPeriod()
        {
            return _period;
        }

        public int? GetShift()
        {
            return _shift;
        }

        public List<double> GetGeneratedValues()
        {
            return _generatedValues.Select(x => (double)x / M).ToList();
        }

        public void Dispose()
        {
            Reset();
        }
    }
}
