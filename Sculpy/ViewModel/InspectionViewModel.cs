using System.ComponentModel;
using System.Runtime.CompilerServices;
using Sculpy.Annotations;
using Sculpy.Model;

namespace Sculpy.ViewModel
{
    public class InspectionViewModel:INotifyPropertyChanged
    {
        /// <summary>
        /// Property that refers to InspectionCatalogSingleton
        /// </summary>
        public InspectionCatalogSingleton InspectionCatalogSingleton { get; set; }

        public InspectionViewModel()
        {
            // Creates an instance of InspectionCatalogSingleton
            InspectionCatalogSingleton = InspectionCatalogSingleton.Instance;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}