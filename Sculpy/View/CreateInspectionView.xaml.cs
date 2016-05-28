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
    public sealed partial class CreateInspectionView : Page
    {
        public CreateInspectionView()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// This method is called when we navigate to this page.
        /// </summary>
        /// <param name="e">This parameter holds the value which was passed from the SelectedSculpturePage.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var sculpture = (Sculpture)e.Parameter;
            ViewModel.Sculpture = sculpture;
            if (sculpture != null) ViewModel.NewInspection = new Inspection(sculpture.ID);
        }

        /// <summary>
        /// When the user decides to create the inspection, this method will be called.
        /// Here we call the handler to create a new inspection,
        /// we refresh the catalog of inspections
        /// and we navigate back to the SelectedSculpture Page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void AcceptButton_OnClick(object sender, RoutedEventArgs e)
        {
            ViewModel.NewInspection.Sculpture_ID = ViewModel.Sculpture.ID;
            InspectionHandler.CreateInspection(ViewModel.NewInspection);
            InspectionCatalogSingleton.Instance.Inspections = await new Persistancy.PersistenceFacade().GetAllInspections();
            Frame.Navigate(typeof(SelectedSculptureView), ViewModel.Sculpture);
        }

        /// <summary>
        /// This method is called when the user wants to cancel the operation fo creating a new inspection.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SelectedSculptureView), ViewModel.Sculpture);
        }
    }
}
