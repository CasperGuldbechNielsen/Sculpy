using System.Windows.Input;
using Sculpy.Common;
using Sculpy.Handler;

namespace Sculpy.ViewModel
{
    public class MapViewModel
    {
        public ICommand setLocationCommand { get; set; }


        MapHandler MapHandler { get; set; }

        public MapViewModel()
        {
            MapHandler = new MapHandler(this);

            setLocationCommand = new RelayCommand(MapHandler.CurrentLocation);
        } 
    }
}