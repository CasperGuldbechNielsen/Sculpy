using System;
using System.Linq;
using Sculpy.Model;

namespace Sculpy.Handler
{
    public class ReportHandler
    {
        private static SculptureCatalogSingleton CatalogSingleton { get; } = SculptureCatalogSingleton.Instance;

        internal static void FilterCollectionByPeriod(string periodFilter)
        {
            var filteredCollection =
                            CatalogSingleton.Sculptures.Where(x => x.Sculpture_Placement == periodFilter).ToList();

            CatalogSingleton.Sculptures.Clear();

            foreach (var sculpture in filteredCollection)
            {
                CatalogSingleton.Sculptures.Add(sculpture);
            }
        }

        internal static void FilterCollectionByDamage(string damageFilter)
        {
            var filteredCollection =
                            CatalogSingleton.Sculptures.Where(x => x.Sculpture_Placement == damageFilter).ToList();

            CatalogSingleton.Sculptures.Clear();

            foreach (var sculpture in filteredCollection)
            {
                CatalogSingleton.Sculptures.Add(sculpture);
            }
        }

        internal static void FilterCollectionByTreatmentFrequency(string treatmentFrequencyFilter)
        {
            var filteredCollection =
                            CatalogSingleton.Sculptures.Where(x => x.Sculpture_Placement == treatmentFrequencyFilter).ToList();

            CatalogSingleton.Sculptures.Clear();

            foreach (var sculpture in filteredCollection)
            {
                CatalogSingleton.Sculptures.Add(sculpture);
            }
        }

        internal static void FilterCollectionBySuggestedTreatment(string suggestedTreatmentFilter)
        {
            var filteredCollection =
                            CatalogSingleton.Sculptures.Where(x => x.Sculpture_Placement == suggestedTreatmentFilter).ToList();

            CatalogSingleton.Sculptures.Clear();

            foreach (var sculpture in filteredCollection)
            {
                CatalogSingleton.Sculptures.Add(sculpture);
            }
        }
    }
}