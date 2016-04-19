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

        private void LoadInspections()
        {
            Inspections = new ObservableCollection<Inspection>(new PersistenceFacade().GetAllInspections());

        }

        public void Add(int iD, string inspection_Date, string inspection_Note, int sculpture_ID, string damage_Picture)
        {
            Inspections.Add(new Inspection(iD, inspection_Date, inspection_Note, sculpture_ID, damage_Picture));
        }
    }
}