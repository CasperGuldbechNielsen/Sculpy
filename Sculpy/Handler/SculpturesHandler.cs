using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Sculpy.Model;
using Sculpy.View;
using Sculpy.ViewModel;
using static Sculpy.ViewModel.SculpturesViewModel;
using SculptureCatalogSingleton = Sculpy.Model.SculptureCatalogSingleton;

namespace Sculpy.Handler
{
    public class SculpturesHandler
    { 
        private static SculptureCatalogSingleton CatalogSingleton { get; } = SculptureCatalogSingleton.Instance;


        public static void FilterCollectionByPlacement(string criteria)
        {
            var filteredCollection =
                CatalogSingleton.Sculptures.Where(x => x.Sculpture_Placement == criteria).ToList();

            CatalogSingleton.Sculptures.Clear();

            foreach (var sculpture in filteredCollection)
            {
                CatalogSingleton.Sculptures.Add(sculpture);
            }
        }

        public static void FilterCollectionByType(string criteria)
        {
            
        }

        public static void SortCollection(string criteria)
        {
            var sortedCollection =
                CatalogSingleton.Sculptures.OrderBy(x => x.Sculpture_Name).ToList();

            CatalogSingleton.Sculptures.Clear();

            foreach (var sculpture in sortedCollection)
            {
                CatalogSingleton.Sculptures.Add(sculpture);
            }

        }

    }
}
