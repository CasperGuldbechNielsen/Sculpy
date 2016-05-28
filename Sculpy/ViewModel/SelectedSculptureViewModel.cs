using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Windows.Devices.Bluetooth.Background;
using Sculpy.Annotations;
using Sculpy.Common;
using Sculpy.Handler;
using Sculpy.Model;

namespace Sculpy.ViewModel
{
    public class SelectedSculptureViewModel:INotifyPropertyChanged
    {
        /// <summary>
        /// A reference to the Catalog of inspections.
        /// </summary>
        public InspectionCatalogSingleton InspectionCatalogSingleton { get; set; }

        /// <summary>
        /// A reference to the handler related to an inspection.
        /// </summary>
        public InspectionHandler InspectionHandler { get; set; }

        /// <summary>
        /// A reference to the handler related to a sculpture.
        /// </summary>
        public SculptureHandler SculptureHandler { get; set; }

        private Inspection _newInspection;
        /// <summary>
        /// A property saves deta
        /// </summary>
        public Inspection NewInspection
        { 
            get { return _newInspection; }
            set { _newInspection = value; OnPropertyChanged(); }
        }



        private Sculpture _passedSculpture;
        public Sculpture PassedSculpture
        {
            get { return _passedSculpture; }
            set
            {
                _passedSculpture = value; 
                OnPropertyChanged();
            }
        }

        private Inspection _passedInspection;
        /// <summary>
        /// This property holds an inspection which is passed as a parameter when navigating to another page.
        /// </summary>
        public Inspection PassedInspection
        {
            get { return _passedInspection; }
            set
            {
                _passedInspection = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// This property is an ICommand which is binded to the Delete Sculpture button from the View.
        /// </summary>
        public ICommand DeleteCommand { get; set; }

        /// <summary>
        /// In the constructor we need to instantiate some of the fields and properties.
        /// </summary>
        public SelectedSculptureViewModel()
        {
            // Creates an instance of InspectionCatalogSingleton
            InspectionCatalogSingleton = InspectionCatalogSingleton.Instance;

            // Creates an instance of InspectionHandler
            InspectionHandler = new Handler.InspectionHandler(this);

            SculptureHandler = new SculptureHandler();

            // Creates an instance of NewInspection
            NewInspection = new Inspection();

            DeleteCommand = new RelayCommand(async () => await SculptureHandler.DeleteSculpture(PassedSculpture.ID));

        }

        /// <summary>
        /// Implementation for the INotifyPropertyChanged interface.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}