using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Sculpy.Persistancy;

namespace Sculpy.Model
{
    /// <summary>
    /// This class contains the Catalog of sculptures.
    /// Also it implements the Singleton Pattern due to the fact that we need to have only one instance of the collection of sculptures.
    /// </summary>
    public class SculptureCatalogSingleton
    {
        /// <summary>
        /// Through this property we can access the collection of sculptures.
        /// </summary>
        public static SculptureCatalogSingleton Instance { get; } = new SculptureCatalogSingleton();

        /// <summary>
        /// This collection holds all the sculpture objects.
        /// </summary>
        public ObservableCollection<Sculpture> Sculptures { get; set; }

        /// <summary>
        /// This constructor is private due to the fact that this class implementst the Singleton Pattern.
        /// </summary>
        private SculptureCatalogSingleton()
        {
            LoadSculptures();
        }

        /// <summary>
        /// Load all the sculptures from the Database through the Persistency Facade.
        /// </summary>
        private async void LoadSculptures()
        {
            Sculptures = await new PersistenceFacade().GetAllSculptures();

            foreach (var sculpture in Sculptures.Where(sculpture => sculpture.ID < 15))
            {
                sculpture.SculptureTypes = await new PersistenceFacade().GetSculptureTypesAsync(sculpture.ID);
                sculpture.SculptureMaterials = await new PersistenceFacade().GetSculptureMaterialsAsync(sculpture.ID);
                var inspections = await new PersistenceFacade().GetInspetionsFromSelectedSculpture(sculpture.ID);
                sculpture.LastInspection = inspections.Max(x => x.Inspection_Date);
            }
        }
    }
}