using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Sculpy.Annotations;
using Sculpy.Common;
using Sculpy.Handler;
using Sculpy.View;

namespace Sculpy.ViewModel
{
    public class MapViewModel : INotifyPropertyChanged
    {
        public ICommand setLocationCommand { get; set; }

        private Geopoint _mapcenter;
        public Geopoint mapcenter
        {
            get { return _mapcenter; }
            set
            {
                _mapcenter = value;
                OnPropertyChanged();
            }
        }

        private double _zoomlevel;

        public double zoomLevel
        {
            get { return _zoomlevel;}
            set
            {
                _zoomlevel = value;
                OnPropertyChanged();
            }
        }

        private Geopoint _myLocation;

        public Geopoint MyLocation
        {
            get { return _myLocation; }
            set
            {
                _myLocation = value;
                OnPropertyChanged();
            }
            
        }

        private bool _mapmessage;

        public bool mapMessage
        {
            get { return _mapmessage;}
            set
            {
                _mapmessage = value;
                OnPropertyChanged();
            }
        }

        private bool _showLocation;

        public bool showLocation
        {
            get { return _showLocation; }
            set
            {
                _showLocation = value;
                OnPropertyChanged();
            }
        }

        MapHandler MapHandler { get; set; }

        public MapViewModel()
        {
            MapHandler = new MapHandler(this);

            setLocationCommand = new RelayCommand(MapHandler.CurrentLocation);

            mapMessage = false;
            showLocation = false;
            _showLocation = false;
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