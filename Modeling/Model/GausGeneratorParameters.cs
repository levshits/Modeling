using System;
using System.Collections.Generic;
using Modeling.Common;

namespace Modeling.Model
{
    public class GausGeneratorParameters : InitialParametersBase
    {
        private int _mx;
        private int _sigmax;
        private int _n;
        public override List<Guid> AllowedGenerators => new List<Guid> {GeneratorsConstants.GAUSS_GENERATOR};
        public override bool IsValid => N > 0;

        public int Mx
        {
            get { return _mx; }
            set
            {
                _mx = value;
                OnPropertyChanged();
            }
        }

        public int SigmaX
        {
            get { return _sigmax; }
            set
            {
                _sigmax = value;
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
