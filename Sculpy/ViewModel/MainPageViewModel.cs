using Windows.Devices.Geolocation;

namespace Sculpy.ViewModel
{
    public class MainPageViewModel
    {
        private Geopoint _cityCenter;

        public MainPageViewModel()
        {
            BasicGeoposition cityPosition = new BasicGeoposition() { Latitude = 55.690241, Longitude = 12.508998 };
            _cityCenter = new Geopoint(cityPosition);

            
        }

        public Geopoint MapPoint
        {
            get { return _cityCenter; }
            set { _cityCenter = value; }
        }
    }
}