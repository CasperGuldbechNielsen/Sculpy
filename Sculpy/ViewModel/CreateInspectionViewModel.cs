using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml.Controls;
using Sculpy.Annotations;
using Sculpy.Handler;
using Sculpy.Model;

namespace Sculpy.ViewModel
{
    public class CreateInspectionViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// This property holds the passed inspection.
        /// </summary>
        public Sculpture Sculpture { get; set; }

        private Inspection _newInspection;
        /// <summary>
        /// This property holds the values for the new created inspection.
        /// </summary>
        public Inspection NewInspection
        {
            get { return _newInspection; }
            set
            {
                _newInspection = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// This property allows us to take the content from a ComboBox control and save it in the new created inspection.
        /// </summary>
        public ComboBoxItem ComboBoxItemDetail
        {
            set
            {
                var tag = value?.Tag?.ToString();
                switch (tag)
                {
                    case "Damage":
                        NewInspection.Damage_Type = value?.Content?.ToString();
                        break;
                    case "Treatment":
                        NewInspection.Treatment_Type = value?.Content?.ToString();
                        break;
                    case "Frequency":
                        NewInspection.Treatment_Plan = value?.Content?.ToString();
                        break;
                    default: throw new Exception();
                }
            }
        }

        public CreateInspectionViewModel() {}

        /// <summary>
        /// Implementation for INotifyPropertyChanged interface
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}