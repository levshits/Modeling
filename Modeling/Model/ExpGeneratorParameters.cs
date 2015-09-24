using System;
using System.Collections.Generic;
using Modeling.Common;

namespace Modeling.Model
{
    public class ExpGeneratorParameters : InitialParametersBase
    {
        private int _lambda;
        public override List<Guid> AllowedGenerators => new List<Guid> {GeneratorsConstants.EXP_GENERATOR};
        public override bool IsValid => Lambda != 0;

        public int Lambda
        {
            get { return _lambda; }
            set
            {
                _lambda = value;
                OnPropertyChanged();
            }
        }
    }
}
