using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Sculpy.Annotations;
using Sculpy.Handler;
using Sculpy.Model;

namespace Sculpy.ViewModel
{
    public class SelectedInspectionEditViewModel:INotifyPropertyChanged
    {
        /// <summary>
        /// This property is a reference to the Catalog of inspections.
        /// </summary>
        public InspectionCatalogSingleton InspectionCatalogSingleton { get; set; }

        private Inspection _selectedInspection;
        /// <summary>
        /// This property gets the values of the passed inspection when the user navigates to SelectedInspection Page.
        /// </summary>
        public Inspection SelectedInspection
        {
            get { return _selectedInspection; }
            set
            {
                _selectedInspection = value;
                OnPropertyChanged();
            }
        }

        public InspectionHandler Handler { get; }

        /// <summary>
        /// This property extracts the tag of the ComboBox control and save it in the Inspection property.
        /// </summary>
        public ComboBoxItem ComboBoxItemDetail
        {
            set
            {
                var tag = value?.Tag?.ToString();
                switch (tag)
                {
                    case "Damage":
                        SelectedInspection.Damage_Type = value?.Content?.ToString();
                        break;
                    case "Treatment":
                        SelectedInspection.Treatment_Type = value?.Content?.ToString();
                        break;
                    case "Frequency":
                        SelectedInspection.Treatment_Plan = value?.Content?.ToString();
                        break;
                    default: throw new Exception();
                }
            }
        }

        /// <summary>
        /// This property sets the placeholder text of the ComboBox control to what was passed in the parameter.
        /// </summary>
        public void MaterialCheckBox_IsEnabled(object sender, RoutedEventArgs e)
        {
            var comboBox = (ComboBox)sender;
            
            var tag = comboBox?.Tag?.ToString();
            switch (tag)
            {
                case "Damage":
                    comboBox.PlaceholderText = SelectedInspection.Damage_Type;
                    break;
                case "Treatment":
                    comboBox.PlaceholderText = SelectedInspection.Treatment_Type;
                    break;
                case "Frequency":
                    comboBox.PlaceholderText = SelectedInspection.Treatment_Plan;
                    break;
                default: throw new Exception();
            }
        }


        public SelectedInspectionEditViewModel()
        {
            
        }

        /// <summary>
        /// Implementation of the INotifyPropertyChanged interface.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}