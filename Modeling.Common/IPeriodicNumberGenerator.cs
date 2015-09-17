using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modeling.Common
{
    /// <summary>
    /// Interface IPeriodicNumberGenerator
    /// </summary>
    public interface IPeriodicNumberGenerator: IRandomNumberGenerator
    {
        /// <summary>
        /// Gets the period.
        /// Return null if cycle not already detected
        /// </summary>
        int? GetPeriod();

        /// <summary>
        /// Gets the shift.
        /// Return null if cycle not already detected
        /// </summary>
        int? GetShift();
    }
}
