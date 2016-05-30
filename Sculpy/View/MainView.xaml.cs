using System;
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
using Sculpy.Model;

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
            // setting the main frame to load the sculptures view. 
            MainFrame.Navigate(typeof(SculpturesView));
        }

        /// <summary>
        /// This method is called when a button from the header is pressed.
        /// Through this we navigate to other pages.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonHeader_OnClick(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;

            switch (int.Parse(button.Tag.ToString()))
            {
                case 1:
                    MainFrame.Navigate(typeof(SculpturesView));
                    break;
                case 2:
                    MainFrame.Navigate(typeof(MapView));
                    break;
                case 3:
                    MainFrame.Navigate(typeof(ReportView));
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// This method is executed when the user chooses one item from the suggested list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void SearchBox_OnSuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            var sculptureName = args.SelectedItem as string;
            sender.Text = string.Format("{0}", sculptureName);
            var sculpture = SculptureCatalogSingleton.Instance.Sculptures.First(x => x.Sculpture_Name == sender.Text);
            MainFrame.Navigate(typeof(SelectedSculptureView), sculpture);
        }
    }
}
