﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using Windows.UI.Popups;
using Newtonsoft.Json;
using Sculpy.Model;
using Sculpy.ViewModel;

namespace Sculpy.Handler
{
    public class ReportHandler
    {
        private static InspectionCatalogSingleton CatalogSingleton { get; } = InspectionCatalogSingleton.Instance;

        public ReportViewModel reportViewModel { get; set; }

        public ReportHandler(ReportViewModel reportViewModel)
        {
            this.reportViewModel = reportViewModel;
        }
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
            }
        }

        internal static void FilterCollectionByDamage(string damageFilter)
        {
            var filteredCollection =
                            CatalogSingleton.Inspections.Where(x => x.Inspection_Note == damageFilter).ToList();

            CatalogSingleton.Inspections.Clear();

            foreach (var sculpture in filteredCollection)
            {
                CatalogSingleton.Inspections.Add(sculpture);
            }
        }

        internal static void FilterCollectionByTreatmentFrequency(string treatmentFrequencyFilter)
        {
            var filteredCollection =
                            CatalogSingleton.Inspections.Where(x => x.Inspection_Note == treatmentFrequencyFilter).ToList();

            CatalogSingleton.Inspections.Clear();

            foreach (var sculpture in filteredCollection)
            {
                CatalogSingleton.Inspections.Add(sculpture);
            }
        }

        internal static void FilterCollectionBySuggestedTreatment(string suggestedTreatmentFilter)
        {
            var filteredCollection =
                            CatalogSingleton.Inspections.Where(x => x.Inspection_Note == suggestedTreatmentFilter).ToList();

            CatalogSingleton.Inspections.Clear();

            foreach (var sculpture in filteredCollection)
            {
                CatalogSingleton.Inspections.Add(sculpture);
            }
        }

        public async void DrawReport(List<Inspection> inspections)
        {
            // Make report here

            StringBuilder builder = new StringBuilder();

            foreach (var item in inspections) // Loop through all strings
            {
                builder.AppendFormat(item.ToString());
            }


            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile = await storageFolder.CreateFileAsync("Report.txt", Windows.Storage.CreationCollisionOption.ReplaceExisting);

            await Windows.Storage.FileIO.WriteTextAsync(sampleFile, builder.ToString());


            MessageDialog dialog = new MessageDialog("A report has been saved to your harddrive.");
            dialog.ShowAsync();
        }
    }
}