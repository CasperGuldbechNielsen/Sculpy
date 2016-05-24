using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private void SettingsButton_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SettingsView));
        }

        private void EditSculptureButton_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SelectedSculptureEditView), ViewModel.PassedSculpture);
        }

        private void InspectionListView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Frame.Navigate(typeof(SelectedInspectionView), ViewModel.PassedInspection);
        }

        private void SelectedInspectionButton_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CreateInspectionView), ViewModel.PassedSculpture);
        }

        // TODO Sometimes it only deletes from the view, but not the database. Also, when you confirm that you want to delete it doesn't go back to the SculpturesView

        private async void DeleteSculptureButton_OnClick(object sender, RoutedEventArgs e)
        {
            DeleteSculptureContentDialog.Visibility = Visibility.Visible;
            ContentDialogResult result = await DeleteSculptureContentDialog.ShowAsync();
        }
    }
}
