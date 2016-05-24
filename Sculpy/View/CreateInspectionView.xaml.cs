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

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var sculpture = (Sculpture)e.Parameter;
            ViewModel.Sculpture = sculpture;
            if (sculpture != null) ViewModel.NewInspection = new Inspection(sculpture.ID);
        }

        // TODO Currently no binding on comboboes which means that Damage, Treatment and Treatment plan isn't saved. Also: When creating the new inspection by pressing save, the inspection doesn't also appear on the listview with inspection on the SelectedSculptureView

        private void AcceptButton_OnClick(object sender, RoutedEventArgs e)
        {
            ViewModel.NewInspection.Sculpture_ID = ViewModel.Sculpture.ID;
            InspectionHandler.CreateInspection(ViewModel.NewInspection);

            Frame.Navigate(typeof (SelectedSculptureView), ViewModel.Sculpture);
        }

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SelectedSculptureView), ViewModel.Sculpture);
        }
    }
}
