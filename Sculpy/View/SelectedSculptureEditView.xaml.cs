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
using Sculpy.ViewModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Sculpy.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SelectedSculptureEditView : Page
    {
        public SelectedSculptureEditView()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var sculpture = e.Parameter;
            ViewModel.PassedSculpture = (Sculpture)sculpture;
        }

        private async void AcceptButton_OnClick(object sender, RoutedEventArgs e)
        {
            await new Persistancy.PersistenceFacade().UpdateSculptureAsync(ViewModel.PassedSculpture);
            Frame.Navigate(typeof(SelectedSculptureView), ViewModel.PassedSculpture);
        }

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SelectedSculptureView), ViewModel.PassedSculpture);
        }
    }
}
