using Levshits.Wpf.Common.Model;

namespace Modeling.Model
{
    /// <summary>
    /// Class InitialParametersModel.
    /// </summary>
    public class InitialParametersModel: ModelBase
    {
        private int _a;
        private int _m;
        private int _initialValue;

        /// <summary>
        /// Gets or sets a pareeter at Lemere formula.
        /// </summary>
        /// <value>a.</value>
        public int A { get { return _a; }
            set
            {
                _a = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Gets or sets the m at Lemere formula.
        /// </summary>
        /// <value>The m.</value>
        public int M
        {
            get { return _m; }
            set
            {
                _m = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Gets or sets the initial value at Lemere formula.
        /// </summary>
        /// <value>The initial value.</value>
        public int InitialValue
        {
            get { return _initialValue; }
            set
            {
                _initialValue = value;
                OnPropertyChanged();
            }
        }
    }
}