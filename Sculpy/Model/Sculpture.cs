using System;

namespace Sculpy.Model
{
    /// <summary>
    /// This class represents the sculptures from the database
    /// </summary>
    public class Sculpture
    {
        public int ID { get; set; }
        public string Sculpture_Name { get; set; }
        public string Sculpture_Placement { get; set; }
        public string Sculpture_Address { get; set; }
        public string Sculpture_Description { get; set; }
        public string Sculpture_Inspection_Frequency { get; set; }
        public string Sculpture_Picture { get; set; }

        public Sculpture(int ID, string Sculpture_Name, string Sculpture_Placement, string Sculpture_Address,
            string Sculpture_Description, string Sculpture_Inspection_Frequency, string Sculpture_Picture)
        {
            this.ID = ID;
            this.Sculpture_Name = Sculpture_Name;
            this.Sculpture_Placement = Sculpture_Placement;
            this.Sculpture_Address = Sculpture_Address;
            this.Sculpture_Description = Sculpture_Description;
            this.Sculpture_Inspection_Frequency = Sculpture_Inspection_Frequency;
            this.Sculpture_Picture = Sculpture_Picture;
        }
        public Sculpture()
        {
            
        }

        /// <summary>
        /// This method overrides ToString() method in order to display the sculpture the way we want
        /// </summary>
        /// <returns>A string with the properties of a sculpture.</returns>
        public override string ToString()
        {
            return string.Format("Id: {0}\nName: {1}\nAddress: {2}\nDescription: {3}\nPlacement: {4}\nInspection Frequency: {5}\nPicture: {6}", 
            ID, Sculpture_Name, Sculpture_Address, Sculpture_Description, 
            Sculpture_Placement, Sculpture_Inspection_Frequency, Sculpture_Picture);
        }
    }
}