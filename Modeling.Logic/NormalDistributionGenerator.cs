using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Modeling.Common;

namespace Modeling.Logic
{
    public class NormalDistributionGenerator: IRandomNumberGenerator
    {
        public string Name => "NormalDistributionGenerator";
        public Guid Id => GeneratorsConstants.NORMAL_DISTRIBUTION_GENERATOR;
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
            return _a.Value+(_b.Value-_a.Value)*_random.NextDouble();
        }

        public void Reset()
        {
            _a = null;
            _b = null;
        }
    }
}
