using System.ComponentModel;
using System.Runtime.CompilerServices;
using Sculpy.Annotations;
using Sculpy.Model;

namespace Sculpy.ViewModel
{
    public class CreateInspectionViewModel : INotifyPropertyChanged
    {

        public Sculpture Sculpture { get; set; }

        private Inspection _newInspection;

        public Inspection NewInspection
        {
            get { return _newInspection; }
            set
            {
                _newInspection = value;
                OnPropertyChanged();
            }
        }

        public CreateInspectionViewModel()
        {
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}