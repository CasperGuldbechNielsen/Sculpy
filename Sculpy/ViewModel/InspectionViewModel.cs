using System.ComponentModel;
using System.Runtime.CompilerServices;
using Sculpy.Annotations;

namespace Sculpy.ViewModel
{
    public class InspectionViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}