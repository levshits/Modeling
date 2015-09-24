using System;
using Modeling.Common;

namespace Modeling.Logic
{
    public class GaussGenerator: IRandomNumberGenerator
    {
        private int? _n;
        private int _sigmaX;
        public string Name => "Gauss generator";
        public Guid Id => GeneratorsConstants.GAUSS_GENERATOR;
        public int Mx { get; set; }
        public int SigmaX { get; set; }
        public int N { get; set; }
        private readonly Random _random = new Random();
        private int _mx;

        public double Next()
        {
            if (!_n.HasValue)
            {
                _n = N;
                _sigmaX = SigmaX;
                _mx = Mx;
            }
            var summ = 0.0;
            for (int i = 0; i < _n; i++)
            {
                summ += _random.NextDouble();
            }
            return _mx + _sigmaX*Math.Sqrt((double) 12/_n.Value)*(summ - (double)_n.Value / 2);
        }

        public void Reset()
        {
            _n = null;
        }
    }
}
