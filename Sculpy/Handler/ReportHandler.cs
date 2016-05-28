using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Windows.UI.Popups;
using Newtonsoft.Json;
using Sculpy.Model;
using Sculpy.ViewModel;
using UnicodeEncoding = Windows.Storage.Streams.UnicodeEncoding;

namespace Sculpy.Handler
{
    public class ReportHandler
    {
        /// <summary>
        /// This property represents a reference to the Catalog of all inspections which implements the Singleton Pattern.
        /// </summary>
        private static InspectionCatalogSingleton CatalogSingleton { get; } = InspectionCatalogSingleton.Instance;

        /// <summary>
        /// This property is a reference to the ViewModel associated to the Report Page.
        /// </summary>
        public ReportViewModel ReportViewModel { get; set; }

        /// <summary>
        /// In the constructor of this page we need to instantiate the ViewModel class.
        /// </summary>
        /// <param name="reportViewModel"></param>
        public ReportHandler(ReportViewModel reportViewModel)
        {
            this.ReportViewModel = reportViewModel;
        }

        /// <summary>
        /// This method is called whenever the user wants to filter the Catalog of inspections on a specific period of time.
        /// </summary>
        /// <param name="periodFilter">This parameter will hold that specific period of time chosen by the user.</param>
        internal static void FilterCollectionByPeriod(int periodFilter)
        {
            var today = DateTime.Now;
            switch (periodFilter)
            {
                // Filter for a day
                case 1:
                    var filteredCollectionDay = CatalogSingleton.Inspections.Where(x => x.Inspection_Date >= today.AddDays(-1)).ToList();

                    CatalogSingleton.Inspections.Clear();

                    foreach (var sculpture in filteredCollectionDay)
                    {
                        CatalogSingleton.Inspections.Add(sculpture);
                    }
                    break;
                // Filter for a week
                case 7:
                    var filteredCollectionWeek = CatalogSingleton.Inspections.Where(x => x.Inspection_Date >= today.AddDays(-7)).ToList();

                    CatalogSingleton.Inspections.Clear();

                    foreach (var sculpture in filteredCollectionWeek)
                    {
                        CatalogSingleton.Inspections.Add(sculpture);
                    }
                    break;
                // Filter for a month
                case 30:
                    var filteredCollectionMonth = CatalogSingleton.Inspections.Where(x => x.Inspection_Date >= today.AddDays(-31)).ToList();

                    CatalogSingleton.Inspections.Clear();

                    foreach (var sculpture in filteredCollectionMonth)
                    {
                        CatalogSingleton.Inspections.Add(sculpture);
                    }
                    break;
                // Filter for a year
                case 365:
                    var filteredCollectionYear = CatalogSingleton.Inspections.Where(x => x.Inspection_Date >= today.AddDays(-365)).ToList();

                    CatalogSingleton.Inspections.Clear();

                    foreach (var sculpture in filteredCollectionYear)
                    {
                        CatalogSingleton.Inspections.Add(sculpture);
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// This method is called whenever the user wants to filter the Catalog of inspections by a chosen damage type.
        /// </summary>
        /// <param name="damageFilter">This parameter holds the value of the chosen damage type.</param>
        internal static void FilterCollectionByDamage(string damageFilter)
        {
            var filteredCollection =
                            CatalogSingleton.Inspections.Where(x => x.Damage_Type == damageFilter).ToList();

            CatalogSingleton.Inspections.Clear();

            foreach (var sculpture in filteredCollection)
            {
                CatalogSingleton.Inspections.Add(sculpture);
            }
        }

        /// <summary>
        /// This method is called whenever the user wants to filter the Catalog of inspections by a chosen treatment frequency.
        /// </summary>
        /// <param name="treatmentFrequencyFilter">This parameter holds the value of the chosen treatment frequency.</param>
        internal static void FilterCollectionByTreatmentFrequency(string treatmentFrequencyFilter)
        {
            var filteredCollection =
                            CatalogSingleton.Inspections.Where(x => x.Treatment_Plan == treatmentFrequencyFilter).ToList();

            CatalogSingleton.Inspections.Clear();

            foreach (var sculpture in filteredCollection)
            {
                CatalogSingleton.Inspections.Add(sculpture);
            }
        }

        /// <summary>
        /// This method is called whenever the user wants to filter the Catalog of inspections by a chosen treatment type.
        /// </summary>
        /// <param name="suggestedTreatmentFilter">This parameter holds the value of the chosen treatment type.</param>
        internal static void FilterCollectionBySuggestedTreatment(string suggestedTreatmentFilter)
        {
            var filteredCollection =
                            CatalogSingleton.Inspections.Where(x => x.Treatment_Type == suggestedTreatmentFilter).ToList();

            CatalogSingleton.Inspections.Clear();

            foreach (var sculpture in filteredCollection)
            {
                CatalogSingleton.Inspections.Add(sculpture);
            }
        }

        /// <summary>
        /// Create a report based on the inspections passed as a parameter
        /// </summary>
        /// <param name="inspections"></param>
        public async void DrawReport(List<Inspection> inspections)
        {
            // Create an empty string builder to make the report string
            var builder = new StringBuilder();

            // Loop through the inspections passed in as parameter
            // to build the string for the report
            foreach (var item in inspections) // Loop through all strings
            {
                builder.AppendLine("Inspection-ID: " + item.ID);
                builder.AppendLine("Inspection Date: " + item.Inspection_Date);
                builder.AppendLine("Inspection Note: " + item.Inspection_Note);
                builder.AppendLine("Sculpture-ID: " + item.Sculpture_ID);
                builder.AppendLine("\n");
            }

            var result = builder.ToString();
            // Open the folder:
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            // Create the file:
            Windows.Storage.StorageFile sampleFile = await storageFolder.CreateFileAsync("Report.txt", Windows.Storage.CreationCollisionOption.ReplaceExisting);
            // Save the file:
            await Windows.Storage.FileIO.WriteTextAsync(sampleFile, result, UnicodeEncoding.Utf8);

            MessageDialog dialog = new MessageDialog("A report has been saved to your harddrive.");
            await dialog.ShowAsync();
        }
    }
}