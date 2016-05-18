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

        public ObservableCollection<Material> MaterialCollection { get; set; } = new ObservableCollection<Material>();
        public ObservableCollection<string> TypeCollection { get; set; } = new ObservableCollection<string>();

        public SculptureHandler Handler { get; }

        /// <summary>
        /// Compiled Bindings or Bindings to Event - new way of binding appeared with C#6-2015.
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
                PassedSculpture.SculptureMaterials.Add(material);
                MaterialCollection.Add(material);
            }
                
        }

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

        public void MaterialCheckBox_IsEnabled(object sender, RoutedEventArgs e)
        {
            var checkBox = (CheckBox)sender;
            var tag = checkBox.Tag.ToString();
            if (PassedSculpture.SculptureMaterials != null && PassedSculpture.SculptureMaterials.Count > 0)
                foreach (var material in PassedSculpture.SculptureMaterials.Where(material => material.Material_Name == tag))
                {
                    // TODO mind-blowing for me 
                    checkBox.IsChecked = true;
                    break;
                }
        }


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


        public ComboBoxItem PlacementBoxItem
        {
            set { PassedSculpture.Sculpture_Placement = value?.Tag?.ToString(); }
        }


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

