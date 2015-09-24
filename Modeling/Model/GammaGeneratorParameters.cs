using System;
using System.Collections.Generic;
using Modeling.Common;

namespace Modeling.Model
{
    public class GammaGeneratorParameters: InitialParametersBase
    {
        private int _lambda;
        private int _n;
        public override List<Guid> AllowedGenerators => new List<Guid> {GeneratorsConstants.GAMMA_GENERATOR};
        public override bool IsValid => Lambda != 0 && N>0;

        public int Lambda
        {
            get { return _lambda; }
            set
            {
                _lambda = value;
                OnPropertyChanged();
            }
        }

        public int N
        {
            get { return _n; }
            set
            {
                _n = value;
                OnPropertyChanged();
            }
        }
    }
}