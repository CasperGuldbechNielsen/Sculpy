using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
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
using Sculpy.Handler;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Sculpy.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MapView : Page
    {
        MarkerHandler MarkerHandler = new MarkerHandler();
        private double _latitude = 55.67610;
        private double _longitude = 12.56834;

        public MapView()
        {
            this.InitializeComponent();
        }

        private async void SculptureMap_OnLoaded(object sender, RoutedEventArgs e)
        {
            var center =
                new Geopoint(new BasicGeoposition()
                {
                    Latitude = _latitude,
                    Longitude = _longitude
                });
            await sculptureMap.TrySetSceneAsync(MapScene.CreateFromLocationAndRadius(center, 3500), MapAnimationKind.Bow);

        }

        private void SettingsButton_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SettingsView));
        }
    }
}
