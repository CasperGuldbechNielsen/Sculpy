using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sculpy.Model;

namespace Sculpy.ViewModel
{
    class ReportViewModel
    {
        public InspectionCatalogSingleton inspectionCatalogSingleton { get; set; }

        public ReportViewModel()
        {
            inspectionCatalogSingleton = InspectionCatalogSingleton.Instance;
        }
    }
}
