using System.ComponentModel;
using System.Runtime.CompilerServices;
using Levshits.Wpf.Common.Annotations;

namespace Levshits.Wpf.Common.Model
{
    public class ModelBase: INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion INotifyPropertyChanged
    }
}