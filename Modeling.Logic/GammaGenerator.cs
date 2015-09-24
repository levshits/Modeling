using System;
using Modeling.Common;

namespace Modeling.Logic
{
    public class GammaGenerator: IRandomNumberGenerator
    {
        private int? _n;
        public string Name => "Gamma generator";
        public Guid Id => GeneratorsConstants.GAMMA_GENERATOR;
        public int Lambda { get; set; }
        public int N { get; set; }
        private readonly Random _random = new Random();
        private int _lambda;

        public double Next()
        {
            if (!_n.HasValue)
            {
                _n = N;
                _lambda = Lambda;
            }
            var p = 1.0;
            for (int i = 0; i < _n; i++)
            {
                p *= _random.NextDouble();
            }
            return -1.0/_lambda * Math.Log(p);
        }

        public void Reset()
        {
            _n = null;
        }
    }
}