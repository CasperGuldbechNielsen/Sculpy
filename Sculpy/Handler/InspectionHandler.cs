using Sculpy.Model;
using Sculpy.Persistancy;
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
            Inspection inspection = new Inspection();
            inspection.ID = InspectionViewModel.NewInspection.ID;
            inspection.Inspection_Date = InspectionViewModel.NewInspection.Inspection_Date;
            inspection.Inspection_Note = InspectionViewModel.NewInspection.Inspection_Note;
            inspection.Sculpture_ID = InspectionViewModel.NewInspection.Sculpture_ID;
            inspection.Damage_Picture = InspectionViewModel.NewInspection.Damage_Picture;

            new PersistenceFacade().SaveInspection(inspection);

            var inspections = new PersistenceFacade().GetAllInspections();

            InspectionViewModel.InspectionCatalogSingleton.Inspections.Clear();

            foreach (var inspection1 in inspections)
            {
                InspectionViewModel.InspectionCatalogSingleton.Inspections.Add(inspection1);
            }
        }

        //TODO Not finished as we need to decide if we will have a SelectedInspection property in InspectionViewModel
        public void DeleteInspection()
        {
            //new PersistenceFacade().RemoveInspection(InspectionViewModel.SelectedInspection);

            //var inspections = new PersistenceFacade().GetAllInspections();

            //InspectionViewModel.InspectionCatalogSingleton.Inspections.Clear();
            //foreach (var inspection1 in inspections)
            //{
            //    InspectionViewModel.InspectionCatalogSingleton.Inspections.Add(inspection1);
            //}
        }
    }
}