using Windows.Devices.Geolocation;
using Sculpy.Model;

namespace Sculpy.ViewModel
{
    public class MainPageViewModel
    {
        private Geopoint _cityCenter;

        public SculptureCatalogSingleton SculptureCatalogSingleton { get; set; }

        public MainPageViewModel()
        {
            BasicGeoposition cityPosition = new BasicGeoposition() { Latitude = 55.690241, Longitude = 12.508998 };
            _cityCenter = new Geopoint(cityPosition);

            SculptureCatalogSingleton = SculptureCatalogSingleton.Instance;

        }

        public Geopoint MapPoint
        {
            get { return _cityCenter; }
            set { _cityCenter = value; }
        }
    }
}