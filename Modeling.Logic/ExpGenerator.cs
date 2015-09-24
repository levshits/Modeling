using System;
using Modeling.Common;

namespace Modeling.Logic
{
    public class ExpGenerator: IRandomNumberGenerator
    {
        private int? _lambda;
        public string Name => "Exp generator";
        public Guid Id => GeneratorsConstants.EXP_GENERATOR;

        public int Lambda { get; set; }
        private readonly Random _random = new Random();
        public double Next()
        {
            if (!_lambda.HasValue)
            {
                _lambda = Lambda;
            }
            return -1.0/Lambda*Math.Log(_random.NextDouble());
        }

        public void Reset()
        {
            _lambda = null;
        }
    }
}