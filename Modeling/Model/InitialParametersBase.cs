using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Levshits.Wpf.Common.Model;

namespace Modeling.Model
{
    public abstract class InitialParametersBase: ModelBase
    {
        public abstract List<Guid> AllowedGenerators { get;}
        public abstract bool IsValid { get;}
    }
}
