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
using Sculpy.Model;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Sculpy.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SelectedInspectionEditView : Page
    {
        public SelectedInspectionEditView()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var inspection = (Inspection)e.Parameter;
            ViewModel.SelectedInspection = inspection;
        }       

        /// <summary>
        /// When an inspection is edited this method is called in order to update the inspection in the Database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            await new Persistancy.PersistenceFacade().UpdateEditedInspection(ViewModel.SelectedInspection);
            Frame.Navigate(typeof (SelectedInspectionView), ViewModel.SelectedInspection);
        }

        /// <summary>
        /// If the user wants to cancel the edit inspection operation, he will go back to the SelectedInspection Page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SelectedInspectionView), ViewModel.SelectedInspection);
        }
    }
}
