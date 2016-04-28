using Sculpy.Model;

namespace Sculpy.ViewModel
{
    public class ReportViewModel
    {
        InspectionCatalogSingleton inspectionCatalogSingleton { get; set; }
        public ReportViewModel()
        {
            inspectionCatalogSingleton = InspectionCatalogSingleton.Instance;
        } 
    }
}