using System.ComponentModel;
using System.Runtime.CompilerServices;
using Sculpy.Annotations;
using Sculpy.Handler;
using Sculpy.Model;

namespace Sculpy.ViewModel
{
    public class SelectedInspectionEditViewModel:INotifyPropertyChanged
    {
        public InspectionCatalogSingleton InspectionCatalogSingleton { get; set; }

        private Inspection _selectedInspection;

        public Inspection SelectedInspection
        {
            get { return _selectedInspection; }
            set
            {
                _selectedInspection = value;
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
            InspectionCatalogSingleton = InspectionCatalogSingleton.Instance;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}