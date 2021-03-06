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

        /// <summary>
        /// This method adds all the selected inspections to a collection.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Reports_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var mySelectedItems = Reports.SelectedItems.Cast<Inspection>().ToList();

            ViewModel.SelectedInspections = mySelectedItems;
        }
    }
}
