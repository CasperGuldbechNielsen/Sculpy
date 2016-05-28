using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Sculpy.Annotations;
using Sculpy.Common;
using Sculpy.Handler;
using Sculpy.Model;

namespace Sculpy.ViewModel
{
    class SelectedInspectionViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// This property represents a reference to the Catalog of inspections.
        /// </summary>
        public InspectionCatalogSingleton InspectionCatalogSingleton { get; set; }

        /// <summary>
        /// This property represents a reference to the handler related to inspections.
        /// </summary>
        public InspectionHandler InspectionHandler { get; set; }

        public SelectedSculptureViewModel SelectedSculptureViewModel { get; set; }   

        private Inspection _selectedInspection;
        /// <summary>
        /// This property will save an inspection when the user selects one from the list.
        /// </summary>
        public Inspection SelectedInspection
        {
            get { return _selectedInspection; }
            set
            {
                _selectedInspection = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// This property holds the inspection which is passed when the user navigates to SelectedInspectionView page.
        /// </summary>
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
        
        public SelectedInspectionViewModel()
        {
            InspectionCatalogSingleton = InspectionCatalogSingleton.Instance;

            InspectionHandler = new InspectionHandler(SelectedSculptureViewModel);
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
