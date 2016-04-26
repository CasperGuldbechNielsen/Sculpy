﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
using Microsoft.Xaml.Interactions.Core;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Sculpy.View
{
    public sealed partial class Sculptures : UserControl
    {
        public Sculptures()
        {
            this.InitializeComponent();

            var frameworkElement = this.Content as FrameworkElement;
            if (frameworkElement != null) frameworkElement.DataContext = this;
        }

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
        

        private void SculptureListView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            


        }

        
    }
}
