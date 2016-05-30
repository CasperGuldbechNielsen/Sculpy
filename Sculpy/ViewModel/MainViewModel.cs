using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Sculpy.Model;
using Sculpy.View;

namespace Sculpy.ViewModel
{
    class MainViewModel
    {
        /// <summary>
        /// This method updates the list which is suggested in the AutoSuggestBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void SearchBox_OnTextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            var allItems = SculptureCatalogSingleton.Instance.Sculptures;

            var listOfSculptureNames = allItems.Select(place => place.Sculpture_Name).ToList();

            string[] filtered = { };

            if (listOfSculptureNames != null && listOfSculptureNames.Any())
            {
                filtered = listOfSculptureNames.Where(p => p.StartsWith(sender.Text, StringComparison.OrdinalIgnoreCase)).ToArray();
            }

            sender.ItemsSource = filtered;
        }
    }
}
