using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Sculpy.Annotations;
using Sculpy.Common;
using Sculpy.Handler;
using Sculpy.Model;

namespace Sculpy.ViewModel
{
    class SelectedSculptureEditViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// This property contains the parameter of type Sculpture which is passed when we nagivate to SelectedSculptureEditView page.
        /// </summary>
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

        public Sculpture UnchangedSculpture { get; set; }

        public ObservableCollection<Material> MaterialCollection { get; set; } = new ObservableCollection<Material>();
        public ObservableCollection<string> TypeCollection { get; set; } = new ObservableCollection<string>();

        public SculptureHandler Handler { get; }

        /// <summary>
        /// Compiled Bindings or Bindings to Event - new way of binding appeared with C#6-2015.
        /// This method is binded to a Check event and we are able to save all the materials which the user selects.
        /// </summary>
        public void MaterialCheckBox_OnChecked(object sender, RoutedEventArgs args)
        {
            var checkBox = (CheckBox)sender;
            var tag = checkBox.Tag.ToString();
            var material = new Material(tag);

            if (PassedSculpture.SculptureMaterials != null && PassedSculpture.SculptureMaterials.Count > 0)
            {
                if (PassedSculpture.SculptureMaterials.All(material1 => material1.Material_Name != material.Material_Name))
                {
                    PassedSculpture.SculptureMaterials.Add(material);
                    MaterialCollection.Add(material);
                }
            }
            else
            {
                PassedSculpture.SculptureMaterials?.Add(material);
                MaterialCollection.Add(material);
            }
        }

        /// <summary>
        /// This method is binded to the Unchecked event of the CheckBox control.
        /// This method removes unchecked materials from the collection of materials related to that Sculpture.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MaterialCheckBox_OnUnchecked(object sender, RoutedEventArgs e)
        {
            var checkBox = (CheckBox)sender;
            var tag = checkBox.Tag.ToString();
            var material = new Material(tag);

            var collection =
                PassedSculpture.SculptureMaterials.Where(material1 => material1.Material_Name != material.Material_Name).ToList();
            PassedSculpture.SculptureMaterials.Clear();
            MaterialCollection.Clear();
            collection.ForEach(material1 => PassedSculpture.SculptureMaterials.Add(material1));
            collection.ForEach(material1 => MaterialCollection.Add(material1));
        }

        /// <summary>
        /// This method is binded to the IsEnabled method of the CheckBox control.
        /// This method checkes the CheckBox if the material is already owned by the Sculpture.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MaterialCheckBox_IsEnabled(object sender, RoutedEventArgs e)
        {
            var checkBox = (CheckBox)sender;
            var tag = checkBox.Tag.ToString();
            if (PassedSculpture.SculptureMaterials != null && PassedSculpture.SculptureMaterials.Count > 0)
                foreach (var material in PassedSculpture.SculptureMaterials.Where(material => material.Material_Name == tag))
                {
                    checkBox.IsChecked = true;
                    break;
                }
        }

        /// <summary>
        /// Compiled Bindings or Bindings to Event - new way of binding appeared with C#6-2015.
        /// This method is binded to a Check event and we are able to save all the type of sculpture which the user selects.
        /// </summary>
        public void TypeCheckBox_OnChecked(object sender, RoutedEventArgs args)
        {
            var checkBox = (CheckBox)sender;
            var type = checkBox.Tag.ToString();

            if (PassedSculpture.SculptureTypes.All(type1 => type1 != type))
            {
                PassedSculpture.SculptureTypes.Add(type);
                TypeCollection.Add(type);
            }
        }

        /// <summary>
        /// This method is binded to the Unchecked event of the CheckBox control.
        /// This method removes unchecked types of the sculpture from the collection of types related to that Sculpture.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TypeCheckBox_OnUnchecked(object sender, RoutedEventArgs e)
        {
            var checkBox = (CheckBox)sender;
            var type = checkBox.Tag.ToString();

            var collection =
                PassedSculpture.SculptureTypes.Where(type1 => type1 != type).ToList();
            PassedSculpture.SculptureTypes.Clear();
            TypeCollection.Clear();
            collection.ForEach(type1 => PassedSculpture.SculptureTypes.Add(type1));
            collection.ForEach(type1 => TypeCollection.Add(type1));
        }

        /// <summary>
        /// This method is binded to the IsEnabled method of the CheckBox control.
        /// This method checkes the CheckBox if the type is already saved for that Sculpture.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TypeCheckBox_IsEnabled(object sender, RoutedEventArgs e)
        {
            var checkBox = (CheckBox)sender;
            var tag = checkBox.Tag.ToString();
            foreach (var type in PassedSculpture.SculptureTypes.Where(type => type == tag))
            {
                checkBox.IsChecked = true;
                break;
            }
        }

        /// <summary>
        /// This property extracts the Placement property from the ComboBox.
        /// </summary>
        public ComboBoxItem PlacementBoxItem
        {
            set { PassedSculpture.Sculpture_Placement = value?.Tag?.ToString(); }
        }


        public SelectedSculptureEditViewModel()
        {

        }
        
        /// <summary>
        /// Implementation for the INotifyPropertyChanged interface.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

