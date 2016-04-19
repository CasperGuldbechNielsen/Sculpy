namespace Sculpy.Model
{
    /// <summary>
    /// This class represents inspections in the database
    /// </summary>
    public class Inspection
    {
        public int ID { get; set; }
        public string Inspection_Date { get; set; }
        public string Inspection_Note { get; set; }
        public string Sculpture_ID { get; set; }
        public string Damage_Picture { get; set; }

        public Inspection(int iD, string inspection_Date, string inspection_Note, string sculpture_ID, string damage_Picture)
        {
            ID = iD;
            Inspection_Date = inspection_Date;
            Inspection_Note = inspection_Note;
            Sculpture_ID = sculpture_ID;
            Damage_Picture = damage_Picture;
        }

        public Inspection()
        {
            
        }

        // TODO: Make ToString method...
    }
}