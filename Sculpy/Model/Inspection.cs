using System;

namespace Sculpy.Model
{
    /// <summary>
    /// This class represents inspections in the database
    /// </summary>
    public class Inspection
    {
        public string Title { get; set; }
        public int ID { get; set; }
        public DateTime Inspection_Date { get; set; }
        public string Inspection_Note { get; set; }
        public int Sculpture_ID { get; set; }
        public string Damage_Picture { get; set; }

        public Inspection(int iD, string title, DateTime inspection_Date, string inspection_Note, int sculpture_ID, string damage_Picture)
        {
            ID = iD;
            Title = title;
            Inspection_Date = inspection_Date;
            Inspection_Note = inspection_Note;
            Sculpture_ID = sculpture_ID;
            Damage_Picture = damage_Picture;
        }

        public Inspection()
        {
            
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}, {3}, {4}", ID, Title, Inspection_Date, Inspection_Note, Sculpture_ID);
        }

        // TODO: Make ToString method...
    }
}