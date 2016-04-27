using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sculpy.Model;
using Sculpy.ViewModel;
using static Sculpy.ViewModel.SculpturesViewModel;

namespace Sculpy.Handler
{
    public static class SculpturesHandler
    {
        public static ObservableCollection<Sculpture> FilterCollection()
        {
            var filtered = FilteredSortedCollection.Where(x => x.Sculpture_Placement == "Building").ToList();



            return null;
        }
    }
}
