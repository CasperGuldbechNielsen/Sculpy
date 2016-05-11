﻿using System;
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
    class SelectedInspectionViewModel:INotifyPropertyChanged
    {

        public InspectionCatalogSingleton InspectionCatalogSingleton { get; set; }

        public InspectionHandler InspectionHandler { get; set; }

        public SelectedSculptureViewModel SelectedSculptureViewModel { get; set; }

        public ICommand DeleteCommand { get; set; }

        public ICommand CreateCommand { get; set; }

        
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

        
        public SelectedInspectionViewModel()
        {
            InspectionCatalogSingleton = InspectionCatalogSingleton.Instance;

            //In the InspectionHandler why are we passing the SelectedSculptureViewModel?
            InspectionHandler = new InspectionHandler(SelectedSculptureViewModel);
            
            DeleteCommand = new RelayCommand(() => InspectionHandler.DeleteInspection(SelectedInspection.ID));
            CreateCommand = new RelayCommand(() => InspectionHandler.CreateInspection());

        }

        
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}