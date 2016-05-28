using System;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Sculpy.ViewModel;

namespace Sculpy.Handler
{
    public class MapHandler
    {
        /// <summary>
        /// Here we declared a new property thorugh which we refere the ViewModel associated to the Map class.
        /// </summary>
        private MapViewModel MapViewModel { get; }

        /// <summary>
        /// In the constructor we instantiate the ViewModel property.
        /// </summary>
        /// <param name="mapViewModel"></param>
        public MapHandler(MapViewModel mapViewModel)
        {
            this.MapViewModel = mapViewModel;
        }

        /// <summary>
        /// This method will direct the map to show our current location.
        /// </summary>
        public async void CurrentLocation()
        {
            try
            {
                MapViewModel.MapMessage = true;
                var position = (await new Geolocator().GetGeopositionAsync()).Coordinate.Point;
                MapViewModel.MyLocation = position;
                MapViewModel.ShowLocation = true;
                MapViewModel.ZoomLevel = 17;
                MapViewModel.Mapcenter = position;
                MapViewModel.MapMessage = false;
            }
            catch (Exception)
            {
                var errorMessage = new MessageDialog("There is no connection to the location service.");
                await errorMessage.ShowAsync();
                MapViewModel.MapMessage = false;
            }
        }
    }
}