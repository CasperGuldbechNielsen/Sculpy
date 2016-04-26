using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Sculpy.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MapView : Page
    {
        public MapView()
        {
            this.InitializeComponent();
            sculptureMap.Loaded += SculptureMap_OnLoaded;
        }

        private async void SculptureMap_OnLoaded(object sender, RoutedEventArgs e)
        {
            var center =
                new Geopoint(new BasicGeoposition()
                {
                    Latitude = 55.67437,
                    Longitude = 12.56751,
                });
            await sculptureMap.TrySetSceneAsync(MapScene.CreateFromLocationAndRadius(center, 3500));

            //Testing pushpins...
            var pushpin = new MapIcon();

            pushpin.Location = new Geopoint(new BasicGeoposition()
            {
                Latitude = 55.67573,
                Longitude = 12.56858
            });

            pushpin.Title = "Dragespringvandet";

            sculptureMap.MapElements.Add(pushpin);

        }
    }
}
