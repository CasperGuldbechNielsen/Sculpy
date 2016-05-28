using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
using Sculpy.ViewModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Sculpy.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SelectedSculptureView : Page
    {
        public SelectedSculptureView()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var sculpture = e.Parameter;
            ViewModel.PassedSculpture = (Sculpture)sculpture;
            if (ViewModel.PassedSculpture != null)
                InspectionCatalogSingleton.Instance.Inspections = new ObservableCollection<Inspection>(new Persistancy.PersistenceFacade().GetInspetionsFromSelectedSculpture(ViewModel.PassedSculpture.ID).Result);
        }

        /// <summary>
        /// This methods handle the navigation to other pages.
        /// </summary>
        #region Navigate methods.

        private void SettingsButton_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof (SettingsView));
        }

        private void EditSculptureButton_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof (SelectedSculptureEditView), ViewModel.PassedSculpture);
        }

        private void InspectionListView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Frame.Navigate(typeof (SelectedInspectionView), ViewModel.PassedInspection);
        }

        private void SelectedInspectionButton_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof (CreateInspectionView), ViewModel.PassedSculpture);
        }

        #endregion


        /// <summary>
        /// This method will show the dialog box when the user wants to delete a sculpture.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void DeleteSculptureButton_OnClick(object sender, RoutedEventArgs e)
        {
            DeleteSculptureContentDialog.Visibility = Visibility.Visible;
            ContentDialogResult result = await DeleteSculptureContentDialog.ShowAsync();
            DeleteSculptureContentDialog = null;
            await Task.Delay(TimeSpan.FromSeconds(5));
            GoBack();
        }

        /// <summary>
        /// This method is connected to the Delete Sculpture button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private async void Click_OnClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            await SculptureHandler.DeleteSculpture(ViewModel.PassedSculpture.ID);
            InspectionCatalogSingleton.Instance.Inspections = await new Persistancy.PersistenceFacade().GetAllInspections();
            SculptureCatalogSingleton.Instance.Sculptures.Remove(ViewModel.PassedSculpture);
            GoBack();
        }

        private void GoBack()
        {
            Frame.Navigate(typeof(SculpturesView));
        }
    }
}
