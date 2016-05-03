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
    class SelectedSculptureEditViewModel:INotifyPropertyChanged
    {
        private Sculpture _passedSculpture;

        public Sculpture PassedSculpture
        {
            get { return _passedSculpture; }
            set
            {
                _passedSculpture = value;
                OnPropertyChanged();
            }
        }

        public SculptureHandler Handler { get; }


        public SelectedSculptureEditViewModel()
        {
            
        }

        public SelectedSculptureEditViewModel(SculptureHandler handler)
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
