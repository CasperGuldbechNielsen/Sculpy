﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
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

        public ComboBoxItem PlacementBoxItem
        {
            set { NewSculpture.Sculpture_Placement = value?.Tag?.ToString(); }
        }

        public void MaterialCheckBox_OnChecked(object sender, RoutedEventArgs args)
        {
            var checkBox = (CheckBox)sender;
            var tag = checkBox.Tag.ToString();
            var material = new Material(tag);
            if (NewSculpture.SculptureMaterials != null)
            {
                if (NewSculpture.SculptureMaterials.All(material1 => material1.Material_Name != material.Material_Name))
                {
                    NewSculpture.SculptureMaterials.Add(material);
                }
            }
            else
            {
                NewSculpture.SculptureMaterials?.Add(material);
            }
        }

        public void MaterialCheckBox_OnUnchecked(object sender, RoutedEventArgs e)
        {
            var checkBox = (CheckBox)sender;
            var tag = checkBox.Tag.ToString();
            var material = new Material(tag);

            var collection =
                NewSculpture.SculptureMaterials.Where(material1 => material1.Material_Name != material.Material_Name).ToList();
            NewSculpture.SculptureMaterials.Clear();
            collection.ForEach(material1 => NewSculpture.SculptureMaterials.Add(material1));
        }


        public void TypeCheckBox_OnChecked(object sender, RoutedEventArgs args)
        {
            var checkBox = (CheckBox)sender;
            var type = checkBox.Tag.ToString();

            if (NewSculpture.SculptureTypes.Count > 0)
            {
                if (NewSculpture.SculptureTypes.All(type1 => type1 != type))
                {
                    NewSculpture.SculptureTypes.Add(type);
                }
            }
            else
            {
                NewSculpture.SculptureTypes.Add(type);
            }
            
        }

        public void TypeCheckBox_OnUnchecked(object sender, RoutedEventArgs e)
        {
            var checkBox = (CheckBox)sender;
            var type = checkBox.Tag.ToString();

            var collection =
                NewSculpture.SculptureTypes.Where(type1 => type1 != type).ToList();
            NewSculpture.SculptureTypes.Clear();
            collection.ForEach(type1 => NewSculpture.SculptureTypes.Add(type1));
        }

        public CreateSculptureViewModel()
        {
           NewSculpture = new Sculpture(SculptureCatalogSingleton.Instance.Sculptures.Count + 1);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
