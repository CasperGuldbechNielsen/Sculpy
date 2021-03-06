﻿using System;
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
    public sealed partial class CreateSculptureView : Page
    {
        public CreateSculptureView()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// This method is called when the user wants to create a new sculpture.
        /// We are gathering all the information from the ViewModel related to the new sculpture 
        /// and we call the handler to proceed with the creation of the new sculpture.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void AcceptButton_OnClick(object sender, RoutedEventArgs e)
        {
            ViewModel.NewSculpture.ID = SculptureCatalogSingleton.Instance.Sculptures.Last().ID + 1;
            SculptureHandler.CreateSculpture(ViewModel.NewSculpture);

            var parameterList = new List<int>();
            ViewModel.NewSculpture.SculptureMaterials.ForEach(material => parameterList.Add(material.ID));
            await new Persistancy.PersistenceFacade().UpdateSculptureMaterialsAsync(ViewModel.NewSculpture.ID, parameterList);

            var parameterList2 = new List<string>();
            ViewModel.NewSculpture.SculptureTypes.ForEach(type => parameterList2.Add(type));
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
            await new Persistancy.PersistenceFacade().UpdateSculptureTypesAsync(ViewModel.NewSculpture.ID, parameterList);
            Frame.Navigate(typeof(SculpturesView));
        }

        /// <summary>
        /// Through this method we navigate back to the SculpturesView Page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }
    }
}
