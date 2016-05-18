using System;
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

        }

        /// <summary>
        /// Load all Inspections from the persistanceFacade
        /// </summary>
        public async void LoadAllInscpections()
        {
            Inspections = await new PersistenceFacade().GetAllInspections();
        }

        public void Add(int iD, string title, DateTime inspection_Date, string inspection_Note, int sculpture_ID, string damage_Picture, string inspection_title, string treatment_type, string damage_type, string treatment_plan)
        {
            Inspections.Add(new Inspection(iD, inspection_Date, inspection_Note, sculpture_ID, damage_Picture, inspection_title, treatment_type, damage_type, treatment_plan));
        }
    }
}