using System;
using System.Collections.ObjectModel;
using Sculpy.Persistancy;

namespace Sculpy.Model
{
    /// <summary>
    /// This class contains the collection of all the inspections.
    /// It also implements the Singleton Pattern.
    /// </summary>
    public class InspectionCatalogSingleton
    {
        /// <summary>
        /// Through this property we are able to access the collection of inspections. 
        /// </summary>
        public static InspectionCatalogSingleton Instance { get; } = new InspectionCatalogSingleton();

        /// <summary>
        /// This holds all the inspection objects.
        /// </summary>
        public ObservableCollection<Inspection> Inspections { get; set; }

        private InspectionCatalogSingleton()
        {

        }

        /// <summary>
        /// Load all Inspections from the Database through the Persistency Facade class.
        /// </summary>
        public async void LoadAllInscpections()
        {
            Inspections = await new PersistenceFacade().GetAllInspections();
        }
    }
}