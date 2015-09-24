using System;
using Modeling.Common;

namespace Modeling.Logic
{
    public class TriangleGenerator: IRandomNumberGenerator
    {
        public string Name => "Triangle generator";
        public Guid Id => GeneratorsConstants.TRIANGLE_GENERATOR;
        private Random _random = new Random();
        private int? _a;
        private int? _b;
        public int A { get; set; }
        public int B { get; set; }
        public double Next()
        {
            if (!_a.HasValue)
            {
                _a = A;
                _b = B;
            }
            return _a.Value + (_b.Value - _a.Value) * Math.Max(_random.NextDouble(), _random.NextDouble());
        }

        public void Reset()
        {
            _a = null;
            _b = null;
        }
    }
}