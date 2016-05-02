using Windows.Foundation;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Sculpy.ViewModel;

namespace Sculpy.Handler
{
    public class MapHandler
    {
        MarkerHandler MarkerHandler = new MarkerHandler();
        MapViewModel mapViewModel { get; set; }
        public MapHandler(MapViewModel mapViewModel)
        {
            this.mapViewModel = mapViewModel;
        }
        public async void CurrentLocation()
        {
            mapViewModel.mapMessage.Visibility = Visibility.Visible;
            Windows.Devices.Geolocation.Geopoint position = await MarkerHandler.Position();
            DependencyObject marker = MarkerHandler.Marker();
            mapViewModel.mapChildren.Children.Add(marker);
            Windows.UI.Xaml.Controls.Maps.MapControl.SetLocation(marker, position);
            Windows.UI.Xaml.Controls.Maps.MapControl.SetNormalizedAnchorPoint(marker, new Point(0.5, 0.5));
            mapViewModel.zoomLevel.ZoomLevel = 17;
            mapViewModel.mapcenter = position;
            mapViewModel.mapMessage.Visibility = Visibility.Collapsed;
        }

    }
}