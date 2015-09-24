using System;
using System.Collections.Generic;
using System.Linq;
using Modeling.Common;
using Modeling.Model;

namespace Modeling.Logic
{
    public class GeneratorHelper
    {
        public List<IRandomNumberGenerator> NumberGenerators { get; set; }
        public List<InitialParametersBase> InitialParameters { get; set; }

        public IRandomNumberGenerator GetGenerator(Guid id)
        {
            return NumberGenerators.FirstOrDefault(x => x.Id == id);
        }

        public InitialParametersBase GetInitialParametersBase(Guid id)
        {
            return InitialParameters.FirstOrDefault(x => x.AllowedGenerators.Contains(id));
        }

        public Dictionary<Guid, string> Generators => NumberGenerators.ToDictionary(x=>x.Id, x=>x.Name);
    }
}
