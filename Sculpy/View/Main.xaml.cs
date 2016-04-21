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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Sculpy.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Main : Page
    {
        public Main()
        {
            this.InitializeComponent();
        }
        private void Pivot_OnPivotItemLoading(Pivot sender, PivotItemEventArgs args)
        {

            var pivotItemContentControl = CreateUserControlForPivotItem(((Pivot)sender).SelectedIndex);

            args.Item.Content = pivotItemContentControl;
        }

        private static UserControl CreateUserControlForPivotItem(int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    return new Sculptures();
                case 1:
                    return new SelectedSculpture();
                default:
                    throw new ArgumentOutOfRangeException("selectedIndex");
            }
        }
    }
}
