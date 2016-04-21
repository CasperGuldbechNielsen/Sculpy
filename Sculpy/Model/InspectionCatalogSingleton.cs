using System.Collections.ObjectModel;
using Sculpy.Persistancy;

namespace Sculpy.Model
{
    public class InspectionCatalogSingleton
    {
        private static InspectionCatalogSingleton instance = new InspectionCatalogSingleton();

        public static InspectionCatalogSingleton Instance
        {
            get { return instance; }
        }

        public ObservableCollection<Inspection> Inspections { get; set; }

        private InspectionCatalogSingleton()
        {
            LoadInspections();
        }

        /// <summary>
        /// Creates and instance of PersistenceFacade and gets all inspections
        /// </summary>
        private void LoadInspections()
        {
            Inspections = new ObservableCollection<Inspection>
            {
                new Inspection(1, "24/03/2015", "Lorem Ipsum aaaaaaaaaaaaaaaaal the way. You not it!", 1, "Null"),
                new Inspection(1, "12/10/2014", "Lorem Ipsum aaaaaaaaaaaaaaaaal the way. You not it!", 1, "Null"),
                new Inspection(1, "02/01/2012", "Lorem Ipsum aaaaaaaaaaaaaaaaal the way. You not it!", 1, "Null"),
            };
        }

        public void Add(int iD, string inspection_Date, string inspection_Note, int sculpture_ID, string damage_Picture)
        {
            Inspections.Add(new Inspection(iD, inspection_Date, inspection_Note, sculpture_ID, damage_Picture));
        }
    }
}