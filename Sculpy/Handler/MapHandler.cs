using Windows.UI.Popups;
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
        public void CurrentLocation()
        {
            MessageDialog a = new MessageDialog("Hello");
            a.ShowAsync();
        }
    }
}