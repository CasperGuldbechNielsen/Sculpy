using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Sculpy.Handler;
using Sculpy.Model;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Sculpy.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SelectedInspectionView : Page
    {
        public SelectedInspectionView()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// This method is executed when we navigate to this page.
        /// </summary>
        /// <param name="e">This parameter holds the inspection which was selected from the list.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var inspection = (Inspection)e.Parameter;
            ViewModel.SelectedInspection = inspection;
        }

        private void EditInspectionButton_Onclick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SelectedInspectionEditView), ViewModel.SelectedInspection);
        }

        /// <summary>
        /// Through this method we send a delete request to the Web Service.
        /// </summary>
        private async void DeleteInspectionButton_OnClick(object sender, RoutedEventArgs e)
        {
            InspectionHandler.DeleteInspection(ViewModel.SelectedInspection.ID);
            var sculpture = SculptureCatalogSingleton.Instance.Sculptures.First(s => s.ID == ViewModel.SelectedInspection.Sculpture_ID);
            InspectionCatalogSingleton.Instance.Inspections = await new Persistancy.PersistenceFacade().GetAllInspections();
            Frame.Navigate(typeof(SelectedSculptureView), sculpture);
        }
    }
}
