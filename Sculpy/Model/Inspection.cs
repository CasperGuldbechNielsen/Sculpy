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
        public string Treatment_Type { get; set; }
        public string Damage_Type { get; set; }
        public string Treatment_Plan { get; set; }
        
        public Inspection(int id, DateTime inspectionDate, string inspectionNote, int sculptureId, string damagePicture, string inspectionTitle, string treatmentType, string damageType, string treatmentPlan)
        {
            ID = id;
            Inspection_Date = inspectionDate;
            Inspection_Note = inspectionNote;
            Sculpture_ID = sculptureId;
            Damage_Picture = damagePicture;
            Inspection_Title = inspectionTitle;
            Treatment_Type = treatmentType;
            Damage_Type = damageType;
            Treatment_Plan = treatmentPlan;
        }

        public Inspection()
        {

        }

        public override string ToString()
        {
            return string.Format("Inspection-ID: {0}\n" +
                                 "Inspection Date: {1}\n" +
                                 "Inspection Note: {2}\n" +
                                 "Sculpture-ID: {3}\n", ID, Inspection_Date, Inspection_Note, Sculpture_ID);
        }

        // TODO: Make ToString method...
    }
}