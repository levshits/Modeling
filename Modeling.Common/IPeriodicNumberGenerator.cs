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
        /// Gets or sets a value indicating whether this instance is stop iteration if cycle detection enabled.
        /// </summary>
        /// <value><c>true</c> if this instance is stop on cycle detection enabled; otherwise, <c>false</c>.</value>
        bool IsStopOnCycleDetectionEnabled { get; set; }

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
