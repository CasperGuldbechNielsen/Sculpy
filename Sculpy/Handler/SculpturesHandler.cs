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
    /// <summary>
    /// This class contains some of the methods associated to the operations on the entire sculpture collection.
    /// </summary>
    public class SculpturesHandler
    {
        /// <summary>
        /// This property represents a reference to the Catalog of all the sculptures.
        /// </summary>
        private static SculptureCatalogSingleton CatalogSingleton { get; } = SculptureCatalogSingleton.Instance;

        /// <summary>
        /// This method is called whenever the user wants to filter the Catalog of sculptures by a chosen placement type.
        /// </summary>
        /// <param name="criteria">This parameter holds the value of the chosen placement type.</param>
        public static async void FilterCollectionByPlacement(string criteria)
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
                await ResetCollectionAsync();
            }
        }

        /// <summary>
        /// This method is called whenever the user wants to filter the Catalog of sculptures by a chosen type of a sculpture.
        /// </summary>
        /// <param name="criteria">This parameter holds the value of the chosen type of a sculpture.</param>
        public static async void FilterCollectionByType(string criteria)
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
                await ResetCollectionAsync();
            }
        }

        /// <summary>
        /// This method is called whenever the user wants to filter the Catalog of sculptures by a chosen material.
        /// </summary>
        /// <param name="criteria">This parameter holds the value of the chosen material.</param>
        public static async void FilterCollectionByMaterial(string criteria)
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
                await ResetCollectionAsync();
            }
        }

        /// <summary>
        /// This method is called whenever the user wants to sort the collection of sculpture by a specific criteria.
        /// </summary>
        /// <param name="criteria">This parameter holds the value of the chosen criteria by which the list is sorted.</param>
        public static void SortCollection(string criteria)
        {
            List<Sculpture> sortedCollection;

            switch (criteria)
            {
                case "name":
                    sortedCollection = CatalogSingleton.Sculptures.OrderBy(x => x.Sculpture_Name).ToList();
                    break;
                case "inspection":
                    sortedCollection = CatalogSingleton.Sculptures.OrderBy(x => x.LastInspection.Date).ToList();
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

        /// <summary>
        /// This method gets again all the sculpture from the database and refreshes the Catalog of sculptures.
        /// </summary>
        /// <returns></returns>
        public static async Task ResetCollectionAsync()
        {
            var list = await new PersistenceFacade().GetAllSculptures();

            foreach (var sculpture in list.Where(sculpture => sculpture.ID < 15 || sculpture.ID > 200))
            {
                sculpture.SculptureTypes = await new PersistenceFacade().GetSculptureTypesAsync(sculpture.ID);
                sculpture.SculptureMaterials = await new PersistenceFacade().GetSculptureMaterialsAsync(sculpture.ID);
            }

            CatalogSingleton.Sculptures.Clear();

            foreach (var sculpture in list)
            {
                CatalogSingleton.Sculptures.Add(sculpture);
            }
        }
    }
}
