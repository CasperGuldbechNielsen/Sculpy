﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
    public sealed partial class SculpturesView : Page
    {
        public SculpturesView()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// All this methods change the Visibility of certain cotrollers.
        /// </summary>
        #region Visibility methods.

        private void FilterButton_OnClick(object sender, RoutedEventArgs e)
        {
            FilterWindow.Visibility = FilterWindow.Visibility == Visibility.Collapsed
                ? Visibility.Visible
                : Visibility.Collapsed;

            FilterButton.Foreground = FilterWindow.Visibility == Visibility.Collapsed
                ? FilterButton.Foreground = new SolidColorBrush(Colors.White)
                : FilterWindow.BorderBrush;
        }

        private void SortButton_OnClick(object sender, RoutedEventArgs e)
        {
            SortingWindow.Visibility = SortingWindow.Visibility == Visibility.Collapsed
                ? Visibility.Visible
                : Visibility.Collapsed;

            SortButton.Foreground = SortingWindow.Visibility == Visibility.Collapsed
                ? SortButton.Foreground = new SolidColorBrush(Colors.White)
                : SortingWindow.BorderBrush;
        }

        private void MetalCheckBox_OnChecked(object sender, RoutedEventArgs e)
        {
            MetalGrid.Visibility = MetalGrid.Visibility == Visibility.Collapsed
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        private void PlacementToggleSwitch_OnToggled(object sender, RoutedEventArgs e)
        {
            PlacementGrid.Visibility = PlacementGrid.Visibility == Visibility.Collapsed
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        private void TypeToggleSwitch_OnToggled(object sender, RoutedEventArgs e)
        {
            TypeGrid.Visibility = TypeGrid.Visibility == Visibility.Collapsed
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        private void StoneCheckBox_OnChecked(object sender, RoutedEventArgs e)
        {
            StoneGrid.Visibility = StoneGrid.Visibility == Visibility.Collapsed
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        private void OthersCheckBox_OnChecked(object sender, RoutedEventArgs e)
        {
            OthersGrid.Visibility = OthersGrid.Visibility == Visibility.Collapsed
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        #endregion

        /// <summary>
        /// All of these methods are called when the navigation to other pages is required.
        /// </summary>
        #region Navigation methods.

        private void SculptureListView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Frame.Navigate(typeof (SelectedSculptureView), ViewModel.SelectedSculpture);
        }

        private void SettingsButton_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof (SettingsView));
        }

        private void AddSculptureButton_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof (CreateSculptureView));
        }

        #endregion
      
        /// <summary>
        /// These methods are called whenver the user selects a criteria to filter or sort the list of Sculptures.
        /// </summary>
        #region Filter and Sorting methods.
        private void PlacementFilterButton_OnClick(object sender, RoutedEventArgs e)
        {
            var checkBox = (CheckBox) sender;
            var tag = checkBox.Tag.ToString();
            SculpturesHandler.FilterCollectionByPlacement(tag);
        }

        private void TypeFilterButton_OnClick(object sender, RoutedEventArgs e)
        {
            var checkBox = (CheckBox) sender;
            var tag = checkBox.Tag.ToString();
            SculpturesHandler.FilterCollectionByType(tag);
        }

        private void MaterialFilterButton_OnClick(object sender, RoutedEventArgs e)
        {
            var checkBox = (CheckBox) sender;
            var tag = checkBox.Tag.ToString();
            SculpturesHandler.FilterCollectionByMaterial(tag);
        }

        private void SortCheckBox_OnChecked(object sender, RoutedEventArgs e)
        {
            var checkBox = (CheckBox) sender;
            var tag = checkBox.Tag.ToString();
            SculpturesHandler.SortCollection(tag);
        }

        #endregion

        /// <summary>
        /// This method starts the Progress Ring when the sculptures are requested from the Database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            // Delegate method to call the reset.
            ProgressRing.IsActive = true;
            SculptureListView.Opacity = 0.3;
            await SculpturesHandler.ResetCollectionAsync();
            ProgressRing.IsActive = false;
            SculptureListView.Opacity = 1;
        }
    }
}