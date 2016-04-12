using Windows.Devices.Geolocation;

namespace Sculpy.ViewModel
{
    public class MainPageViewModel
    {
        public MainPageViewModel()
        {
            BasicGeoposition cityPosition = new BasicGeoposition() { Latitude = 55.682599, Longitude = 12.499265 };
            Geopoint cityCenter = new Geopoint(cityPosition);

            
        }
    }
}