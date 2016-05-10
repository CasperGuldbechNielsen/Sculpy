using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
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
        private async Task LoadInspections()
        {
            Inspections = await new PersistenceFacade().GetAllInspections();

            //DateTime today = DateTime.Now;

            //Inspections = new ObservableCollection<Inspection>
            //{
            //    new Inspection(1,"General inspection", new DateTime(2016, 05, 08), "Lorem Ipsum aaaaaaaaaaaaaaaaal the way. You not it!", 1, "Null"),
            //    new Inspection(2, "Follow-up inspection", new DateTime(2015, 05, 09), "Lorem Ipsum aaaaaaaaaaaaaaaaal the way. You not it!", 1, "Null"),
            //    new Inspection(3, "General inspection", new DateTime(2016, 05, 02), "Lorem Ipsum aaaaaaaaaaaaaaaaal the way. You not it!", 1, "Null"),
            //};
        }

        public void Add(int iD, string title, DateTime inspection_Date, string inspection_Note, int sculpture_ID, string damage_Picture)
        {
            Inspections.Add(new Inspection(iD, title, inspection_Date, inspection_Note, sculpture_ID, damage_Picture));
        }

        public void LoadAllSculptures()
        {
            LoadInspections();
        }
    }
}