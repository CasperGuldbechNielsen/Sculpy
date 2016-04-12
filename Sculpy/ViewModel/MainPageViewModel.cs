using Windows.Devices.Geolocation;

namespace Sculpy.ViewModel
{
    public class MainPageViewModel
    {
        public MainPageViewModel()
        {
            BasicGeoposition cityPosition = new BasicGeoposition() { Latitude = 47.604, Longitude = -122.329 };
            Geopoint cityCenter = new Geopoint(cityPosition);

            //// Set the map location.
            //MapControl1.Center = cityCenter;
            //MapControl1.ZoomLevel = 12;
            //MapControl1.LandmarksVisible = true;
        }
    }
}