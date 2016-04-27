using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sculpy.Model;

namespace Sculpy.ViewModel
{
    class SculpturesViewModel
    {
        public SculptureCatalogSingleton SculptureCatalogSingleton { get; set; }

        public static ObservableCollection<Sculpture> FilteredSortedCollection { get; set; }


        public SculpturesViewModel()
        {
            SculptureCatalogSingleton = SculptureCatalogSingleton.Instance;

            FilteredSortedCollection = SculptureCatalogSingleton.Instance.Sculptures;
        }




    }
}
