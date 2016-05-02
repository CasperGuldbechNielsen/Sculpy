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

namespace Sculpy.ViewModel
{
    public class MapViewModel : INotifyPropertyChanged
    {
        public ICommand setLocationCommand { get; set; }
        public Geopoint mapcenter { get; set; }
        public MapControl zoomLevel { get; set; }
        public MapControl mapChildren { get; set; }
        public TextBlock mapMessage { get; set; }

        MapHandler MapHandler { get; set; }

        public MapViewModel()
        {
            MapHandler = new MapHandler(this);

            setLocationCommand = new RelayCommand(MapHandler.CurrentLocation);

            mapMessage.Visibility = Visibility.Collapsed;
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