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

        /// <summary>
        /// Creates an Inspection object via properties in the InspectionViewModels NewInspection
        /// </summary>
        public void CreateInspection()
        {

        }

        public void DeleteInspection(int id)
        {

        }

        
    }
}