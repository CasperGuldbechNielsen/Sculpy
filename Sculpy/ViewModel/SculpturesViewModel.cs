using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using Sculpy.Annotations;
using Sculpy.Common;
using Sculpy.Handler;
using Sculpy.Model;
using Sculpy.View;

namespace Sculpy.ViewModel
{
    public class SculpturesViewModel:INotifyPropertyChanged
    {      
        /// <summary>
        /// A reference to the Catalog of sculptures.
        /// </summary>
        public SculptureCatalogSingleton SculptureCatalogSingleton { get; set; }

        public SculpturesViewModel()
        {
            SculptureCatalogSingleton = SculptureCatalogSingleton.Instance;
        }
       
        /// <summary>
        /// This property hold the details passed by the parameter when navigating to the SculpturesView Page.
        /// </summary>
        private Sculpture _selectedSculpture;
        public Sculpture SelectedSculpture
        {
            get { return _selectedSculpture; }
            set
            {
                _selectedSculpture = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// This property extract the placement criteria for filtering and also calls the Filter method for the collection of sculptures.
        /// </summary>
        private string _placementFilter;
        public ComboBoxItem PlacementFilter
        {
            set
            {
                _placementFilter = value?.Tag?.ToString();
                SculpturesHandler.FilterCollectionByPlacement(_placementFilter);
            }
        }


        /// <summary>
        /// This property extract the type of sculpture criteria for filtering and also calls the Filter method for the collection of sculptures.
        /// </summary>
        private string _typeFilter;
        public ComboBoxItem TypeFilter
        {
            set
            {
                _typeFilter = value?.Tag?.ToString();
                SculpturesHandler.FilterCollectionByType(_typeFilter);
            }
        }


        /// <summary>
        /// This property extract the placement criteria for sorting and also calls the Filter method for the collection of sculptures.
        /// </summary>
        private string _sortCriteria;
        public MenuFlyoutItem SortCriteria
        {
            set
            {
                _sortCriteria = value?.Text;
                SculpturesHandler.SortCollection(_sortCriteria);
            }
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
