using System;

namespace Sculpy.Model
{
    /// <summary>
    /// This class represents inspections in the database
    /// </summary>
    public class Inspection
    {
        public int ID { get; set; }
        public DateTime Inspection_Date { get; set; }
        public string Inspection_Note { get; set; }
        public int Sculpture_ID { get; set; }
        public string Damage_Picture { get; set; }
        public string Inspection_Title { get; set; }

        public Inspection(int id, DateTime inspectionDate, string inspectionNote, int sculptureId, string damagePicture, string inspectionTitle)
        {
            ID = id;
            Inspection_Date = inspectionDate;
            Inspection_Note = inspectionNote;
            Sculpture_ID = sculptureId;
            Damage_Picture = damagePicture;
            Inspection_Title = inspectionTitle;
        }

        public Inspection()
        {

        }

        // TODO: Make ToString method...
    }
}