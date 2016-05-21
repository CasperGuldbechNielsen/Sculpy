﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Sculpy.Annotations;

namespace Sculpy.Model
{
    /// <summary>
    /// This class represents the sculptures from the database
    /// </summary>
    public class Sculpture
    {
        private int _id;
        private string _sculptureName;
        private string _sculpturePlacement;
        private string _sculptureAddress;
        private string _sculptureDescription;
        private string _sculptureInspectionFrequency;
        private string _sculpturePicture;
        private string _culturalHeritage;
        private DateTime _lastInspection;
        private List<string> _sculptureTypes;
        private List<Material> _sculptureMaterials;

        public int ID
        {
            get { return _id; }
            set
            {
                if (value > 0)
                {
                    _id = value;
                }
                else
                {
                    var message = $"The id of the sculpture {Sculpture_Name} is wrong.";
                    //new MessageDialog(message).ShowAsync();
                    //throw new IndexOutOfRangeException(message);
                }
            }
        }

        public string Sculpture_Name
        {
            get { return _sculptureName; }
            set
            {
                if (!string.IsNullOrEmpty(value) && value.Length > 2)
                {
                    _sculptureName = value;
                }
                else
                {
                    var message = $"The name of the sculpture {ID} is wrong.";
                    //new MessageDialog(message).ShowAsync();
                    Task.Delay(TimeSpan.FromSeconds(5));
                    //throw new ArgumentException(message);
                }
            }
        }

        public string Sculpture_Placement
        {
            get { return _sculpturePlacement; }
            set
            {
                if (!string.IsNullOrEmpty(value) && value.Length > 2)
                {
                    _sculpturePlacement = value;
                }
                else
                {
                    var message = $"The placement of the sculpture {Sculpture_Name} is wrong.";
                    //new MessageDialog(message).ShowAsync();
                    Task.Delay(TimeSpan.FromSeconds(5));
                    //throw new ArgumentException(message);
                }
            }
        }

        public string Sculpture_Address
        {
            get { return _sculptureAddress; }
            set
            {
                if (!string.IsNullOrEmpty(value) && value.Length > 2)
                {
                    _sculptureAddress = value;
                }
                else
                {
                    var message = $"The address of the sculpture {Sculpture_Name} is wrong.";
                    //new MessageDialog(message).ShowAsync();
                    Task.Delay(TimeSpan.FromSeconds(5));
                    //throw new ArgumentException(message);
                }
            }
        }

        public string Sculpture_Description
        {
            get { return _sculptureDescription; }
            set
            {
                if (!string.IsNullOrEmpty(value) && value.Length > 2)
                {
                    _sculptureDescription = value;
                }
                else
                {
                    _sculptureDescription = value;
                    var message = $"You forgot the description of the sculpture {Sculpture_Name}.";
                    //new MessageDialog(message).ShowAsync();
                }
            }
        }

        public string Sculpture_Inspection_Frequency
        {
            get { return _sculptureInspectionFrequency; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _sculptureInspectionFrequency = value;
                }
                else
                {
                    _sculptureInspectionFrequency = value;
                    var message = $"You forgot the inspection frequency of the sculpture {Sculpture_Name}.";
                    //new MessageDialog(message).ShowAsync();
                } 
            }
        }

        public string Sculpture_Picture
        {
            get { return _sculpturePicture; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _sculpturePicture = value;
                }
                else
                {
                    var message = $"The picture of the sculpture {Sculpture_Name} is not available.";
                    //new MessageDialog(message).ShowAsync();
                }
            }
        }

        public string Cultural_Heritage
        {
            get { return _culturalHeritage; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _culturalHeritage = value;
                }
                else
                {
                    var message = $"The cultural heritage of the sculpture {Sculpture_Name} is not set.";
                    //new MessageDialog(message).ShowAsync();
                    Task.Delay(TimeSpan.FromSeconds(5));
                    //throw new ArgumentException(message);
                }
            }
        }

        public DateTime LastInspection
        {
            get { return _lastInspection; }
            set
            {
                if (value <= DateTime.Today)
                {
                    _lastInspection = value;
                }
                else
                {
                    var message = $"The date of the inspection for {Sculpture_Name} should be in the past.";
                    //new MessageDialog(message).ShowAsync();
                    Task.Delay(TimeSpan.FromSeconds(5));
                    //throw new ArgumentException(message);
                }
            }
        }
       

        public List<string> SculptureTypes
        {
            get { return _sculptureTypes; }
            set
            {
                var collectionOfTypes = new Persistancy.PersistenceFacade().GetAllSculptureTypes().Result.ToList();
                if (value == null || value.Count == 0)
                {
                    var message = $"The type for the sculpture {Sculpture_Name} was not set.";
                    //new MessageDialog(message).ShowAsync();
                    Task.Delay(TimeSpan.FromSeconds(5));
                    //throw new ArgumentNullException(message);
                }
                if (value.Count > collectionOfTypes.Count())
                {
                    var message = $"There were set too many types for the sculpture {Sculpture_Name}.";
                    //new MessageDialog(message).ShowAsync();
                    Task.Delay(TimeSpan.FromSeconds(5));
                    //throw new ArgumentOutOfRangeException(message);
                }
                else
                {
                    _sculptureTypes = value;
                }
            }
        }

        public List<Material> SculptureMaterials
        {
            get { return _sculptureMaterials; }
            set
            {
                var collectionOfMaterials = new Persistancy.PersistenceFacade().GetAllMaterials().Result.ToList();
                if (value.Count == 0)
                {
                    var message = $"The material for the sculpture {Sculpture_Name} was not set.";
                    //new MessageDialog(message).ShowAsync();
                    Task.Delay(TimeSpan.FromSeconds(5));
                    //throw new ArgumentOutOfRangeException(message);
                }
                if (value.Count > collectionOfMaterials.Count())
                {
                    var message = $"There were set too many materials for the sculpture {Sculpture_Name}.";
                    //new MessageDialog(message).ShowAsync();
                    Task.Delay(TimeSpan.FromSeconds(5));
                    //throw new ArgumentOutOfRangeException(message);
                }
                else
                {
                    _sculptureMaterials = value;
                }
            }
        }


        public Sculpture(int ID, string Sculpture_Name, string Sculpture_Placement, string Sculpture_Address,
            string Sculpture_Description, string Sculpture_Inspection_Frequency, string Sculpture_Picture, string Cultural_Heritage)
        {
            this.ID = ID;
            this.Sculpture_Name = Sculpture_Name;
            this.Sculpture_Placement = Sculpture_Placement;
            this.Sculpture_Address = Sculpture_Address;
            this.Sculpture_Description = Sculpture_Description;
            this.Sculpture_Inspection_Frequency = Sculpture_Inspection_Frequency;
            this.Sculpture_Picture = Sculpture_Picture;
            this.Cultural_Heritage = Cultural_Heritage;
        }

        public Sculpture()
        {

        }

        public Sculpture(int id)
        {
            this.ID = id;
            this.Sculpture_Name = null;
            this.Sculpture_Placement = null;
            this.Sculpture_Address = null;
            this.Sculpture_Description = null;
            this.Sculpture_Inspection_Frequency = null;
            this.Sculpture_Picture = null;
            this.SculptureMaterials = new List<Material>();
            this.SculptureTypes = new List<string>();
            this.Cultural_Heritage = null;
        }
        /// <summary>
        /// This method overrides ToString() method in order to display the sculpture the way we want
        /// </summary>
        /// <returns>A string with the properties of a sculpture.</returns>
        public override string ToString()
        {
            return
                $"Id: {ID}\nName: {Sculpture_Name}\nAddress: {Sculpture_Address}\nDescription: {Sculpture_Description}\nPlacement: {Sculpture_Placement}\nInspection Frequency: {Sculpture_Inspection_Frequency}\nPicture: {Sculpture_Picture}";
        }
    }
}