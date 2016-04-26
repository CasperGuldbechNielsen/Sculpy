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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Sculpy.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainView : Page
    {
        public MainView()
        {
            this.InitializeComponent();
        }

        private void HeaderButton_OnPointerEntered(object sender, PointerRoutedEventArgs e)
        {
            var stackpanel = sender as StackPanel;
            stackpanel.BorderBrush = new SolidColorBrush(Colors.White);
        }

        private void ButtonHeader_OnClick(object sender, RoutedEventArgs e)
        {
            var button = (Button) sender;
                       
            switch (int.Parse(button.Tag.ToString()))
            {
                case 1:
                    MainFrame.Navigate(typeof (SculpturesView));
                    break;
                case 2:
                    MainFrame.Navigate(typeof(MainView));
                    break;
                case 3:
                    return;
//                    MainFrame.Navigate(typeof (ReportsView));
//                    break;
                default:
                    throw new Exception();
            }
        }
    }
}
