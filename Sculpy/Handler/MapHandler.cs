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
        MapViewModel mapViewModel { get; set; }

        public MapHandler(MapViewModel mapViewModel)
        {
            this.mapViewModel = mapViewModel;
        }
        public async void CurrentLocation()
        {
            try
            {
                mapViewModel.mapMessage = true;
                var position = (await new Geolocator().GetGeopositionAsync()).Coordinate.Point;
                mapViewModel.MyLocation = position;
                mapViewModel.showLocation = true;
                mapViewModel.zoomLevel = 17;
                mapViewModel.mapcenter = position;
                mapViewModel.mapMessage = false;
            }
            catch (Exception e)
            {
                MessageDialog ErrorMessage = new MessageDialog("There is no connection to the location service.");
                ErrorMessage.ShowAsync();
                mapViewModel.mapMessage = false;
            }
            
        }

    }
}