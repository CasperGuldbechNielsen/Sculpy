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
        /// <summary>
        /// This field is a command which is binded to the XAML View.
        /// </summary>
        public ICommand SetLocationCommand { get; set; }

        /// <summary>
        /// This property sets the Map to the center.
        /// </summary>
        private Geopoint _mapcenter;
        public Geopoint Mapcenter
        {
            get { return _mapcenter; }
            set
            {
                _mapcenter = value;
                OnPropertyChanged();
            }
        }

        private double _zoomlevel;
        /// <summary>
        /// This property handles the zoom level of the Map.
        /// </summary>
        public double ZoomLevel
        {
            get { return _zoomlevel;}
            set
            {
                _zoomlevel = value;
                OnPropertyChanged();
            }
        }

        private Geopoint _myLocation;
        /// <summary>
        /// This property holds the current location of the user.
        /// </summary>
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

        public bool MapMessage
        {
            get { return _mapmessage;}
            set
            {
                _mapmessage = value;
                OnPropertyChanged();
            }
        }

        private bool _showLocation;

        public bool ShowLocation
        {
            get { return _showLocation; }
            set
            {
                _showLocation = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// This is a reference to the handler for Map.
        /// </summary>
        MapHandler MapHandler { get; set; }

        public MapViewModel()
        {
            MapHandler = new MapHandler(this);

            SetLocationCommand = new RelayCommand(MapHandler.CurrentLocation);

            MapMessage = false;
            ShowLocation = false;
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