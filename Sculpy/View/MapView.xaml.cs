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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Sculpy.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MapView : Page
    {

        private CancellationTokenSource _cts = null;
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

        private async void GetGeolocationButton_OnClick(object sender, RoutedEventArgs e)
        {
            GetGeolocationButton.IsEnabled = false;

            try
            {
                // Request permission to access location
                var accessStatus = await Geolocator.RequestAccessAsync();

                switch (accessStatus)
                {
                    case GeolocationAccessStatus.Allowed:

                        // Get cancellation token
                        _cts = new CancellationTokenSource();
                        CancellationToken token = _cts.Token;

                        StatusMessage.Visibility = Visibility.Visible;

                        Geolocator geolocator = new Geolocator();

                        // Carry out the operation
                        Geoposition pos = await geolocator.GetGeopositionAsync().AsTask(token);
                        UpdateLocationData(pos);
                        StatusMessage.Visibility = Visibility.Collapsed;
                        break;

                    case GeolocationAccessStatus.Denied:
                        break;

                    case GeolocationAccessStatus.Unspecified:
                        break;
                }
            }
            finally
            {
                _cts = null;
            }

            GetGeolocationButton.IsEnabled = true;
        }

        private async void UpdateLocationData(Geoposition position)
        {
            _latitude = position.Coordinate.Point.Position.Latitude;
            _longitude = position.Coordinate.Point.Position.Longitude;

            var center =
                new Geopoint(new BasicGeoposition()
                {
                    Latitude = _latitude,
                    Longitude = _longitude
                });
            await
                sculptureMap.TrySetSceneAsync(MapScene.CreateFromLocationAndRadius(center, 200), MapAnimationKind.Bow);
        }
    }
}
