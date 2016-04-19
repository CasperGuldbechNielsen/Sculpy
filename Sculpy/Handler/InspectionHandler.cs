using Sculpy.ViewModel;

namespace Sculpy.Handler
{
    public class InspectionHandler
    {
        //Reference to InspectionViewModel
        public InspectionViewModel InspectionViewModel { get; set; }

        public InspectionHandler(InspectionViewModel inspectionViewModel)
        {
            InspectionViewModel = inspectionViewModel;
        }

        /// <summary>
        /// Creates an Inspection object via properties in the InspectionViewModels NewInspection
        /// </summary>
        public void CreateInspection()
        {
            
        }
    }
}