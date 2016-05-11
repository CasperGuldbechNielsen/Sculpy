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
            LoadInspections();
        }

        /// <summary>
        /// Creates and instance of PersistenceFacade and gets all inspections
        /// </summary>
        private void LoadInspections()
        {
            //Inspections = new ObservableCollection<Inspection>
            //{
            //    new Inspection(1, "24/03/2015", "General inspection", "Lorem Ipsum aaaaaaaaaaaaaaaaal the way. You not it!", 1, "Null"),
            //    new Inspection(1, "12/10/2014", "Follow-up inspection", "Lorem Ipsum aaaaaaaaaaaaaaaaal the way. You not it!", 1, "Null"),
            //    new Inspection(1, "02/01/2012", "General inspection", "Lorem Ipsum aaaaaaaaaaaaaaaaal the way. You not it!", 1, "Null"),
            //};
            //RoomViewModel.RoomsCollection = new ObservableCollection<Room>(new Persistency.PersistenceFacade().GetRoomsAsync(id.Hotel_Number).Result);
            //Inspections = new ObservableCollection<Inspection>(new Persistancy.PersistenceFacade().GetInspetionsFromSelectedSculpture().Result);
        }

        public void LoadAllSculptures()
        {
            //TODO: Implement this
        }

        public void Add(int iD, string title, DateTime inspection_Date, string inspection_Note, int sculpture_ID, string damage_Picture, string inspection_title, string treatment_type, string damage_type, string treatment_plan)
        {
            Inspections.Add(new Inspection(iD, inspection_Date, inspection_Note, sculpture_ID, damage_Picture, inspection_title, treatment_type, damage_type, treatment_plan));
        }
    }
}