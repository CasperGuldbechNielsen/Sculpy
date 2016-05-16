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
            ViewModel.PassedSculpture?.SculptureMaterials.ForEach(material => ViewModel.MaterialCollection.Add(material));
            ViewModel.PassedSculpture?.SculptureTypes.ForEach(type => ViewModel.TypeCollection.Add(type));
        }

        private async void AcceptButton_OnClick(object sender, RoutedEventArgs e)
        {
            await new Persistancy.PersistenceFacade().UpdateSculptureAsync(ViewModel.PassedSculpture);

            var parameterList = new List<int>();
            ViewModel.PassedSculpture.SculptureMaterials.ForEach(material => parameterList.Add(material.ID));
            await new Persistancy.PersistenceFacade().UpdateSculptureMaterialsAsync(ViewModel.PassedSculpture.ID, parameterList);

            var parameterList2 = new List<string>();
            ViewModel.PassedSculpture.SculptureTypes.ForEach(type => parameterList2.Add(type));
            parameterList.Clear();
            parameterList2.ForEach(x =>
            {
                switch (x)
                {
                    case "Skulptur":
                        parameterList.Add(1);
                        break;
                    case "Sokkel":
                        parameterList.Add(2);
                        break;
                    case "Relief":
                        parameterList.Add(3);
                        break;
                    case "Vandkunst":
                        parameterList.Add(4);
                        break;
                    default:
                        break;
                }
            });
            await new Persistancy.PersistenceFacade().UpdateSculptureTypesAsync(ViewModel.PassedSculpture.ID, parameterList);

            Frame.Navigate(typeof(SelectedSculptureView), ViewModel.PassedSculpture);
        }

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SelectedSculptureView), ViewModel.PassedSculpture);
        }
    }
}
