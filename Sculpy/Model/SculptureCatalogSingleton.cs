using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Sculpy.Persistancy;

namespace Sculpy.Model
{
    public class SculptureCatalogSingleton
    {
        private static SculptureCatalogSingleton instance = new SculptureCatalogSingleton();

        public static SculptureCatalogSingleton Instance => instance;

        public ObservableCollection<Sculpture> Sculptures { get; set; }

        private SculptureCatalogSingleton()
        {
            LoadSculptures();
        }
        /// <summary>
        /// Load all sculptures from PersistanceFacade
        /// </summary>
        /// <returns>ObservableCollection of Sculptures</returns>
        private async Task LoadSculptures()
        {
            Sculptures = await new PersistenceFacade().GetAllSculptures();

            foreach (var sculpture in Sculptures)
            {
                if (sculpture.ID < 15)
                {
                    sculpture.SculptureTypes = await new PersistenceFacade().GetSculptureTypesAsync(sculpture.ID);
                    sculpture.SculptureMaterials = await new PersistenceFacade().GetSculptureMaterialsAsync(sculpture.ID);
                    var inspections = await new PersistenceFacade().GetInspetionsFromSelectedSculpture(sculpture.ID);
                    sculpture.LastInspection = inspections.Max(x => x.Inspection_Date);

                }
            }

        }
    }
}