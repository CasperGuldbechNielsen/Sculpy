using Sculpy.Model;
using Sculpy.Persistancy;
using Sculpy.ViewModel;

namespace Sculpy.Handler
{
    public class InspectionHandler
    {

        public SelectedSculptureViewModel InspectionViewModel { get; set; }

        public InspectionHandler(SelectedSculptureViewModel inspectionViewModel)
        {
            InspectionViewModel = inspectionViewModel;
        }

        public static async void CreateInspection(Inspection inspection)
        {
            await new Persistancy.PersistenceFacade().CreateInspectionAsync(inspection);
        }

        public static async void DeleteInspection(int id)
        {
            await new Persistancy.PersistenceFacade().DeleteInspectionAsync(id);
        }

        
    }
}