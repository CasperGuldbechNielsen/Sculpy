using Sculpy.Model;
using Sculpy.Persistancy;
using Sculpy.ViewModel;

namespace Sculpy.Handler
{
    public class InspectionHandler
    {
        /// <summary>
        /// This is a reference to the ViewModel class related to inspections.
        /// </summary>
        public SelectedSculptureViewModel InspectionViewModel { get; set; }

        /// <summary>
        /// In the constructor we need to instantiate the ViewModel property.
        /// </summary>
        /// <param name="inspectionViewModel"></param>
        public InspectionHandler(SelectedSculptureViewModel inspectionViewModel)
        {
            InspectionViewModel = inspectionViewModel;
        }

        /// <summary>
        /// This method calls the Persistency Facade to create a new inspection.
        /// </summary>
        /// <param name="inspection">This is the new created inspection which will be inserted in the Database.</param>
        public static async void CreateInspection(Inspection inspection)
        {
            await new PersistenceFacade().CreateInspectionAsync(inspection);
        }

        /// <summary>
        /// This method calls the Persistency Facade to delete an inspection.
        /// </summary>
        /// <param name="id">We need to pass only the id of the inspection in order to delete it from the Database.</param>
        public static async void DeleteInspection(int id)
        {
            await new PersistenceFacade().DeleteInspectionAsync(id);
        }
    }
}