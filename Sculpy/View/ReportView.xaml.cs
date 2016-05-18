﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Chat;
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
    public sealed partial class ReportView : Page
    {
        public ReportView()
        {
            this.InitializeComponent();
        }

        private void SettingsButton_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SettingsView));
        }

        private void Reports_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Inspection> mySelectedItems = new List<Inspection>();

            foreach (var item in Reports.SelectedItems)
                mySelectedItems.Add((Inspection)item);

            ViewModel.SelectedInspections = mySelectedItems;
        }

        private void CheckAll_OnChecked(object sender, RoutedEventArgs e)
        {

            // TODO: Create the method for selecting all items in the listview.

            //for (int i = 0; i < Reports.Items.Count; i++)
            //{
            //    Reports.Items[i].
            //}
        }
    }
}
