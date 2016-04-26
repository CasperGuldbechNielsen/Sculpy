using System;
using System.ComponentModel;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Windows.ApplicationModel.Store;
using Windows.Devices.Geolocation;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Microsoft.Xaml.Interactions.Core;
using Sculpy.Annotations;
using Sculpy.Model;
using Sculpy.View;

namespace Sculpy.ViewModel
{
    /// <summary>
    /// This class is the ViewModel for our program. It will handle all the communication
    /// between the business logic and the View
    /// </summary>
    public class MainPageViewModel
    {

        public SculptureCatalogSingleton SculptureCatalogSingleton { get; set; }

        public MainPageViewModel()
        {
            BasicGeoposition cityPosition = new BasicGeoposition() { Latitude = 55.690241, Longitude = 12.508998 };
            MapPoint = new Geopoint(cityPosition);

            SculptureCatalogSingleton = SculptureCatalogSingleton.Instance;
            
        }

        /// <summary>
        /// This property is for localising the map where it is wanted on startup
        /// </summary>
        public Geopoint MapPoint { get; set; }



        
    }
}