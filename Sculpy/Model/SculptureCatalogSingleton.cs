using System.Collections.ObjectModel;
using Sculpy.Persistancy;

namespace Sculpy.Model
{
    public class SculptureCatalogSingleton
    {
        private static SculptureCatalogSingleton instance = new SculptureCatalogSingleton();

        public static SculptureCatalogSingleton Instance
        {
            get { return instance; }
        }

        public ObservableCollection<Sculpture> Sculptures { get; set; }

        private SculptureCatalogSingleton()
        {
            //Sculptures.Add(new Sculpture(1, "Yngling til Hest", "Jord", "Rødkilde Plads", "NULL", "NULL", "NULL"));
            //Sculptures.Add(new Sculpture(2, "Arkæologen Georg Zoëga", "Jord", "Glyptotekets anlæg", "Ved Tietgensgade", "NULL", "NULL"));
            //Sculptures.Add(new Sculpture(3, "Kains efterkommere", "Jord", "Lyshøj Allé", "Mod Toftegårds Allé", "NULL", "NULL"));
            //Sculptures.Add(new Sculpture(4, "Mindetavle for Københavns belejring 1658 - 60", "Bygning", "Stormgade", "På Nationalmuseets mur under søjlegalleriet mod Vester Voldgade", "NULL", "NULL"));
            //Sculptures.Add(new Sculpture(5, "Maleren Asmus Jacob Carstens", "Jord", "Glyptotekets anlæg", "Ved Niels Brocksgade", "NULL", "NULL"));

            LoadSculptures();
        }

        private void LoadSculptures()
        {
            Sculptures = new ObservableCollection<Sculpture>(new PersistenceFacade().GetAllSculptures());

        }
    }
}