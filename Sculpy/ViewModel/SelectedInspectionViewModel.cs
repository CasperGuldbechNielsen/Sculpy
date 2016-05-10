using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Sculpy.Annotations;
using Sculpy.Handler;
using Sculpy.Model;

namespace Sculpy.ViewModel
{
    class SelectedInspectionViewModel:INotifyPropertyChanged
    {

        private Inspection _passedInspection;

        public Inspection PassedInspection
        {
            get { return _passedInspection;}
            set
            {
                _passedInspection = value;
                OnPropertyChanged();
            }
        }

        public InspectionHandler Handler { get; }

        public SelectedInspectionViewModel()
        {
            
        }

        public SelectedInspectionViewModel(InspectionHandler handler)
        {
            this.Handler = handler;
        }



        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
