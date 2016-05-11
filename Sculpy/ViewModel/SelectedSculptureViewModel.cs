﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Windows.Devices.Bluetooth.Background;
using Sculpy.Annotations;
using Sculpy.Common;
using Sculpy.Handler;
using Sculpy.Model;

namespace Sculpy.ViewModel
{
    // TODO NOTE THAT NO ICOMMANDS HAS BEEN CREATED AS DANIEL IS PRETTY SURE THAT WE WONT EVEN NEED RelayCommand
    // TODO Toke, I said that but I excluded the cases when we need to send also a parameter. Still I need to read about that.
    public class SelectedSculptureViewModel:INotifyPropertyChanged
    {

        public InspectionCatalogSingleton InspectionCatalogSingleton { get; set; }

        public Handler.InspectionHandler InspectionHandler { get; set; }

        public Handler.SculptureHandler SculptureHandler { get; set; }

        private Inspection _newInspection;
        

        // TODO: The controls for adding a new inspection should be bound to the properties in NewInspection
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

        public Inspection PassedInspection
        {
            get { return _passedInspection; }
            set
            {
                _passedInspection = value;
                OnPropertyChanged();
            }
        }


        public ICommand DeleteCommand { get; set; }


        public SelectedSculptureViewModel()
        {
            // Creates an instance of InspectionCatalogSingleton
            InspectionCatalogSingleton = InspectionCatalogSingleton.Instance;

            // Creates an instance of InspectionHandler
            InspectionHandler = new Handler.InspectionHandler(this);

            SculptureHandler = new SculptureHandler();

            // Creates an instance of NewInspection
            NewInspection = new Inspection();

            DeleteCommand = new RelayCommand(() => SculptureHandler.DeleteSculpture(PassedSculpture.ID));

        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}