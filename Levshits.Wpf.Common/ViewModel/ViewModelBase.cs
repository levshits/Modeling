using System.ComponentModel;
using System.Runtime.CompilerServices;
using Levshits.Wpf.Common.Annotations;

namespace Levshits.Wpf.Common.ViewModel
{
    /// <summary>
    /// Class ViewModelBase(Base class for all view model in wpf c# app).
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
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
