using System.Collections;
using System.Collections.Generic;

namespace Modeling.Common
{
    /// <summary>
    /// Interface IRandomNumberGenerator
    /// </summary>
    public interface IRandomNumberGenerator: IEnumerator<double>
    {
        /// <summary>
        /// Gets the generated values.
        /// </summary>
        List<double> GetGeneratedValues();
    }
}
