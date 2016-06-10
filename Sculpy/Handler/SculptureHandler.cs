using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Controls;
using Sculpy.Model;
using Sculpy.ViewModel;

namespace Sculpy.Handler
{
    /// <summary>
    /// This class contains all the method associated to the CRUD operations for a sculpture object.
    /// </summary>
    public class SculptureHandler
    {
        /// <summary>
        /// In this method we delete a sculpture from the database.
        /// We treated also the scenario when there are references related to a sculpture which is going to be deleted,
        /// ,so we had to take care of all its references across the tables in the database.
        /// </summary>
        /// <param name="id">In order to delete a sculpture we need to have only its ID.</param>
        /// <returns></returns>
        public static async Task DeleteSculpture(int id)
        {
            await new Persistancy.PersistenceFacade().DeleteSculptureTypesAsync(id);
            await new Persistancy.PersistenceFacade().DeleteSculptureMaterialsAsync(id);
            await new Persistancy.PersistenceFacade().DeleteSculptureInspectionsAsync(id);
            await new Persistancy.PersistenceFacade().DeleteSculptureAsync(id);
        }

        /// <summary>
        /// This method is called when the user wants to edit an existing sculpture.
        /// </summary>
        /// <param name="sculpture">In order to save the new details in the database we need the sculpture object as a parameter.</param>
        public static async void UpdateSculpture(Sculpture sculpture)
        {
            await new Persistancy.PersistenceFacade().UpdateSculptureAsync(sculpture);
            SculptureCatalogSingleton.Instance.Sculptures.RemoveAt(sculpture.ID);
            SculptureCatalogSingleton.Instance.Sculptures.Insert(sculpture.ID, sculpture);
        }

        /// <summary>
        /// This method is called when a new sculpture is going to be created.
        /// </summary>
        /// <param name="sculpture">As for the update sculpture, we need also the sculpture object as a parameter.</param>
        public static async void CreateSculpture(Sculpture sculpture)
        {
            await new Persistancy.PersistenceFacade().CreateSculptureAsync(sculpture);
            var parameterList = new List<int>();
            sculpture.SculptureMaterials.ForEach(material => parameterList.Add(material.ID));
            await new Persistancy.PersistenceFacade().UpdateSculptureMaterialsAsync(sculpture.ID, parameterList);

            var parameterList2 = new List<string>();
            sculpture.SculptureTypes.ForEach(type => parameterList2.Add(type));
            parameterList.Clear();
            parameterList2.ForEach(x =>
            {
                switch (x)
                {
                    case "Skulptur":
                        parameterList.Add(1);
                        break;
                    case "Sokkel":
                        parameterList.Add(2);
                        break;
                    case "Relief":
                        parameterList.Add(3);
                        break;
                    case "Vandkunst":
                        parameterList.Add(4);
                        break;
                    default:
                        break;
                }
            });
            await new Persistancy.PersistenceFacade().UpdateSculptureTypesAsync(sculpture.ID, parameterList);
            SculptureCatalogSingleton.Instance.Sculptures.Add(sculpture);
            await SculpturesHandler.ResetCollectionAsync();
        }
    }
}