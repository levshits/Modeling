using Levshits.Wpf.Common.Model;

namespace Modeling.Model
{
    /// <summary>
    /// Class InitialParametersModel.
    /// </summary>
    public class InitialParametersModel: ModelBase
    {
        /// <summary>
        /// Gets or sets a pareeter at Lemere formula.
        /// </summary>
        /// <value>a.</value>
        public int A { get; set; }
        /// <summary>
        /// Gets or sets the m at Lemere formula.
        /// </summary>
        /// <value>The m.</value>
        public int M { get; set; }
        /// <summary>
        /// Gets or sets the initial value at Lemere formula.
        /// </summary>
        /// <value>The initial value.</value>
        public int InitialValue { get; set; } 
    }
}