using System.Collections.Generic;
using System.Linq;
using Modeling.Common;

namespace Modeling.Logic
{
    public class GeneratorContainer
    {
        public Dictionary<string, IRandomNumberGenerator> NumberGenerators { get; set; }

        public IRandomNumberGenerator GetInstance()
        {
            return NumberGenerators.Values.FirstOrDefault();
        }

        public IRandomNumberGenerator GetInstance(string name)
        {
            return NumberGenerators[name];
        }
    }
}
