using Windows.Devices.Geolocation;
using Sculpy.Model;

namespace Sculpy.ViewModel
{
    /// <summary>
    /// This class is the ViewModel for our program. It will handle all the communication
    /// between the business logic and the View
    /// </summary>
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

        /// <summary>
        /// This property is for localising the map where it is wanted on startup
        /// </summary>
        public Geopoint MapPoint
        {
            get { return _cityCenter; }
            set { _cityCenter = value; }
        }
    }
}