using System;
using static System.String;

namespace Sculpy.Model
{
    /// <summary>
    /// This class represents the inspection entity from the database.
    /// </summary>
    public class Inspection
    {
        /// <summary>
        /// Here we have all the properties of an inspection object.
        /// </summary>
        public int ID { get; set; }
        public DateTime Inspection_Date { get; set; }
        public string Inspection_Note { get; set; }
        public int Sculpture_ID { get; set; }
        public string Damage_Picture { get; set; }
        public string Inspection_Title { get; set; }
        public string Treatment_Type { get; set; }
        public string Damage_Type { get; set; }
        public string Treatment_Plan { get; set; }

        /// <summary>
        /// This class has three overloaded contructors.
        /// </summary>
        public Inspection()
        {

        }

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

        public Inspection(int sculptureId)
        {
            this.Sculpture_ID = sculptureId;
            this.ID = InspectionCatalogSingleton.Instance.Inspections.Count + 1;
            this.Damage_Picture = Empty;
            this.Damage_Type = Empty;
            this.Inspection_Date = DateTime.Today;
            this.Inspection_Note = Empty;
            this.Inspection_Title = Empty;
            this.Treatment_Plan = Empty;
            this.Treatment_Type = Empty;
        }

        public override string ToString()
        {
            return $"Inspection-ID: {ID}\n" + $"Inspection Date: {Inspection_Date}\n" +
                   $"Inspection Note: {Inspection_Note}\n" + $"Sculpture-ID: {Sculpture_ID}\n";
        }
    }
}