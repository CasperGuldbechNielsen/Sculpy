using System.ComponentModel;
using System.Runtime.CompilerServices;
using Sculpy.Annotations;
using Sculpy.Handler;
using Sculpy.Model;

namespace Sculpy.ViewModel
{
    public class SelectedInspectionEditViewModel:INotifyPropertyChanged
    {
        private Inspection _passedInspection;

        public Inspection PassedInspection
        {
            get { return _passedInspection; }
            set
            {
                _passedInspection = value;
                OnPropertyChanged();
            }
        }

        public InspectionHandler Handler { get; }


        public SelectedInspectionEditViewModel()
        {
            
        }

        public SelectedInspectionEditViewModel(InspectionHandler handler)
        {
            Handler = handler;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}