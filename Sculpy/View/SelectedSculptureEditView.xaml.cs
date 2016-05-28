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
using Sculpy.Persistancy;
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

        /// <summary>
        /// When we navigate to this page, the bindings have to be set to the values which are passed with the sculpture parameter.
        /// </summary>
        /// <param name="e">This holds the parameter of type Sculpture.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var sculpture = e.Parameter;
            ViewModel.UnchangedSculpture = (Sculpture)sculpture;
            ViewModel.UnchangedSculpture?.SculptureMaterials?.ForEach(material => ViewModel.MaterialCollection.Add(material));
            ViewModel.UnchangedSculpture?.SculptureTypes?.ForEach(type => ViewModel.TypeCollection.Add(type));
            ViewModel.PassedSculpture = new Sculpture();
            ViewModel.PassedSculpture = ViewModel.UnchangedSculpture;
        }

        /// <summary>
        /// This method is called when the user accepts to save the edited sculpture.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void AcceptButton_OnClick(object sender, RoutedEventArgs e)
        {
            await new PersistenceFacade().UpdateSculptureAsync(ViewModel.PassedSculpture);

            var parameterList = new List<int>();
            ViewModel.PassedSculpture.SculptureMaterials.ForEach(material => parameterList.Add(material.ID));
            await new PersistenceFacade().UpdateSculptureMaterialsAsync(ViewModel.PassedSculpture.ID, parameterList);

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
            await new PersistenceFacade().UpdateSculptureTypesAsync(ViewModel.PassedSculpture.ID, parameterList);
            Frame.Navigate(typeof(SelectedSculptureView), ViewModel.PassedSculpture);
        }
        
        /// <summary>
        /// If the user decides to not save the changes to a sculpture,
        /// he can navigate back to the SelectedSculpture Page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            ViewModel.PassedSculpture = new PersistenceFacade().GetOnlyOneSculptures(ViewModel.PassedSculpture.ID).Result;
            ViewModel.PassedSculpture.SculptureTypes = await new PersistenceFacade().GetSculptureTypesAsync(ViewModel.PassedSculpture.ID);
            ViewModel.PassedSculpture.SculptureMaterials = await new PersistenceFacade().GetSculptureMaterialsAsync(ViewModel.PassedSculpture.ID);
            var inspections = await new PersistenceFacade().GetInspetionsFromSelectedSculpture(ViewModel.PassedSculpture.ID);
            if(inspections.Any())ViewModel.PassedSculpture.LastInspection = inspections.Max(x => x.Inspection_Date);
            Frame.Navigate(typeof(SelectedSculptureView), ViewModel.PassedSculpture);
        }
    }
}
