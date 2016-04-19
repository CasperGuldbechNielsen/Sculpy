﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.Devices.Bluetooth.Background;
using Sculpy.Annotations;
using Sculpy.Handler;
using Sculpy.Model;

namespace Sculpy.ViewModel
{
    public class InspectionViewModel:INotifyPropertyChanged
    {

        public InspectionCatalogSingleton InspectionCatalogSingleton { get; set; }

        public Handler.InspectionHandler InspectionHandler { get; set; }

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

            // Creates an instance of InspectionHandler
            InspectionHandler = new Handler.InspectionHandler(this);
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}