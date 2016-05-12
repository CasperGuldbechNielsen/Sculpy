using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Sculpy.Annotations;
using Sculpy.Common;
using Sculpy.Handler;
using Sculpy.Model;

namespace Sculpy.ViewModel
{
    public class CreateSculptureViewModel
    {
       
        private Sculpture _newSculpture;
        public Sculpture NewSculpture
        {
            get { return _newSculpture; }
            set
            {
                _newSculpture = value;
                OnPropertyChanged();
            }
        }

        public CreateSculptureViewModel()
        {
           NewSculpture = new Sculpture(173,"New one","somewhere","somewhere","something","never","none");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
