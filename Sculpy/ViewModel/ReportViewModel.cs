using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml.Controls;
using Sculpy.Annotations;
using Sculpy.Handler;
using Sculpy.Model;

namespace Sculpy.ViewModel
{
    class ReportViewModel : INotifyPropertyChanged
    {
        public InspectionCatalogSingleton inspectionCatalogSingleton { get; set; }

        public ReportViewModel()
        {
            inspectionCatalogSingleton = InspectionCatalogSingleton.Instance;
        }

        private string _periodFilter;
        public ComboBoxItem PeriodFilter
        {
            set
            {
                _periodFilter = value?.Tag?.ToString();
                ReportHandler.FilterCollectionByPeriod(_periodFilter);
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
