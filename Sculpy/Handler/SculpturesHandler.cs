using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Sculpy.Model;
using Sculpy.Persistancy;
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
            if (criteria != "All")
            {
                var filteredCollection =
                CatalogSingleton.Sculptures.Where(x => x.Sculpture_Placement == criteria).ToList();

                CatalogSingleton.Sculptures.Clear();

                foreach (var sculpture in filteredCollection)
                {
                    CatalogSingleton.Sculptures.Add(sculpture);
                }
            }
            else
            {
                ResetCollectionAsync();
            }
        }

        public static void FilterCollectionByType(string criteria)
        {
            if (criteria != "All")
            {
                var filteredCollection = CatalogSingleton.Sculptures
                .Where(sculpture => sculpture.ID < 15)
                .Where(sculpture => sculpture.SculptureTypes.Any(sculptureType => sculptureType == criteria)).ToList();

                CatalogSingleton.Sculptures.Clear();

                foreach (var sculpture in filteredCollection)
                {
                    CatalogSingleton.Sculptures.Add(sculpture);
                }
            }
            else
            {
                ResetCollectionAsync();
            }
        }

        public static void FilterCollectionByMaterial(string criteria)
        {
            if (criteria != "All")
            {
                var filteredCollection = CatalogSingleton.Sculptures
                .Where(sculpture => sculpture.ID < 15)
                .Where(sculpture => sculpture.SculptureMaterials.Any(sculptureMaterial => sculptureMaterial.Material_Name == criteria)).ToList();

                CatalogSingleton.Sculptures.Clear();

                foreach (var sculpture in filteredCollection)
                {
                    CatalogSingleton.Sculptures.Add(sculpture);
                }
            }
            else
            {
                ResetCollectionAsync();
            }
        }

        public static void SortCollection(string criteria)
        {
            var sortedCollection = new List<Sculpture>();

            switch (criteria)
            {
                case "name":
                    sortedCollection = CatalogSingleton.Sculptures.OrderBy(x => x.Sculpture_Name).ToList();
                    break;
                case "inspection":
                    sortedCollection = CatalogSingleton.Sculptures.OrderBy(x => x.LastInspection).ToList();
                    break;
                case "address":
                    sortedCollection = CatalogSingleton.Sculptures.OrderBy(x => x.Sculpture_Address).ToList();
                    break;
                default: throw new Exception(criteria);
            }
            

            CatalogSingleton.Sculptures.Clear();

            foreach (var sculpture in sortedCollection)
            {
                CatalogSingleton.Sculptures.Add(sculpture);
            }

        }

        public static async Task ResetCollectionAsync()
        {
            var list = await new PersistenceFacade().GetAllSculptures();

            foreach (var sculpture in list)
            {
                if (sculpture.ID < 15 || sculpture.ID>200)
                {
                    sculpture.SculptureTypes = await new PersistenceFacade().GetSculptureTypesAsync(sculpture.ID);
                    sculpture.SculptureMaterials = await new PersistenceFacade().GetSculptureMaterialsAsync(sculpture.ID);
                    //sculpture.Inspections = await new PersistenceFacade().GetInspetionsFromSelectedSculpture(sculpture.ID);
                }
            }

            CatalogSingleton.Sculptures.Clear();

            foreach (var sculpture in list)
            {
                CatalogSingleton.Sculptures.Add(sculpture);
            }
        }

    }
}
