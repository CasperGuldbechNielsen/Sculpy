using System.ComponentModel;
using System.Runtime.CompilerServices;
using Sculpy.Annotations;
using Sculpy.Model;

namespace Sculpy.ViewModel
{
    public class InspectionViewModel:INotifyPropertyChanged
    {
        /// <summary>
        /// Property that refers to InspectionCatalogSingleton
        /// </summary>
        public InspectionCatalogSingleton InspectionCatalogSingleton { get; set; }

        private Inspection _newInspection;

        // TODO: The controls for adding a new inspection should be bound to the properties in NewInspection
        public Inspection NewInspection
        { 
            get { return _newInspection; }
            set { _newInspection = value; OnPropertyChanged(); }
        }

        public InspectionViewModel()
        {
            // Creates an instance of InspectionCatalogSingleton
            InspectionCatalogSingleton = InspectionCatalogSingleton.Instance;

            // Creates an instance of NewInspection
            NewInspection = new Inspection();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}