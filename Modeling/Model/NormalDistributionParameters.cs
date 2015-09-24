﻿using System;
using System.Collections.Generic;
using Modeling.Common;

namespace Modeling.Model
{
    public class NormalDistributionParameters: InitialParametersBase
    {
        private int _a;
        private int _b;
        public override List<Guid> AllowedGenerators => new List<Guid> {GeneratorsConstants.NORMAL_DISTRIBUTION_GENERATOR};
        public override bool IsValid => A<B;
        public int A { get { return _a; } set { _a = value; OnPropertyChanged(); } }
        public int B { get { return _b; } set { _b = value; OnPropertyChanged(); } }
    }
}
