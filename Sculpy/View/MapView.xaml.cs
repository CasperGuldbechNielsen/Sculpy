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
using Sculpy.ViewModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Sculpy.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MapView : Page
    {
        public readonly double Latitude = 55.67610;
        private const double Longitude = 12.56834;

        public MapView()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// This method sets the location on the Map.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void SculptureMap_OnLoaded(object sender, RoutedEventArgs e)
        {
            var center =
                new Geopoint(new BasicGeoposition()
                {
                    Latitude = Latitude,
                    Longitude = Longitude
                });
            await sculptureMap.TrySetSceneAsync(MapScene.CreateFromLocationAndRadius(center, 3500), MapAnimationKind.Bow);
        }

        /// <summary>
        /// Through this method we navigate to the Settings Page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingsButton_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SettingsView));
        }
    }
}
