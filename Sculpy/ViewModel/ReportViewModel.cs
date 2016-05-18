using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using Sculpy.Annotations;
using Sculpy.Common;
using Sculpy.Handler;
using Sculpy.Model;

namespace Sculpy.ViewModel
{
    public class ReportViewModel : INotifyPropertyChanged
    {
        public InspectionCatalogSingleton inspectionCatalogSingleton { get; set; }
        public Handler.ReportHandler ReportHandler { get; set; }

        // Invoked when user clicks Draw Report button
        public ICommand DrawReportCommand { get; set; }

        public ReportViewModel()
        {
            ReportHandler = new ReportHandler(this); // Create new instance of reportHandler and pass in this viewmodel
            inspectionCatalogSingleton = InspectionCatalogSingleton.Instance;
            // Load all inspections from the database to populate the listview
            inspectionCatalogSingleton.LoadAllInscpections();
            // Create an action that pass the command to invoke the DrawReport method in reportHandler, pass in the parameter _selectedInspections
            DrawReportCommand = new RelayCommand(() => ReportHandler.DrawReport(_selectedInspections)); 
            // Create a new empty list to pass in as a parameter to the above command
            _selectedInspections = new List<Inspection>();
        }

        private List<Inspection> _selectedInspections; 
        public List<Inspection> SelectedInspections
        {
            get { return _selectedInspections; }
            set
            {
                if (value != null)
                {
                    _selectedInspections = value;
                    OnPropertyChanged();
                }
            }
        } 

        private string _periodFilter;
        public ComboBoxItem PeriodFilter
        {
            set
            {
                _periodFilter = value?.Tag?.ToString();
                ReportHandler.FilterCollectionByPeriod(int.Parse(_periodFilter));
            }
        }

        private string _suggestedTreatmentFilter;
        public ComboBoxItem SuggestedTreatmentFilter
        {
            set
            {
                _suggestedTreatmentFilter = value?.Tag?.ToString();
                ReportHandler.FilterCollectionBySuggestedTreatment(_suggestedTreatmentFilter);
            }
        }

        private string _treatmentFrequencyFilter;
        public ComboBoxItem TreatmentFrequencyFilter
        {
            set
            {
                _treatmentFrequencyFilter = value?.Tag?.ToString();
                ReportHandler.FilterCollectionByTreatmentFrequency(_treatmentFrequencyFilter);
            }
        }

        private string _damageFilter;
        public ComboBoxItem DamageFilter
        {
            set
            {
                _damageFilter = value?.Tag?.ToString();
                ReportHandler.FilterCollectionByDamage(_damageFilter);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
