using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Sculpy.Persistancy;

namespace Sculpy.Model
{
    public class SculptureCatalogSingleton
    {
        private static SculptureCatalogSingleton instance = new SculptureCatalogSingleton();

        public static SculptureCatalogSingleton Instance => instance;

        public ObservableCollection<Sculpture> Sculptures { get; set; }

        public SculptureCatalogSingleton()
        {
            LoadSculptures();
        }

        private async Task LoadSculptures()
        {
            //Sculptures = new ObservableCollection<Sculpture>
            //{
            //    new Sculpture(1, "Yngling til Hest", "Jord", "Rødkilde Plads", "NULL", "NULL", "NULL"),
            //    new Sculpture(2, "Arkæologen Georg Zoëga", "Jord", "Glyptotekets anlæg", "Ved Tietgensgade", "NULL",
            //        "NULL"),
            //    new Sculpture(3, "Kains efterkommere", "Jord", "Lyshøj Allé", "Mod Toftegårds Allé", "NULL", "NULL"),
            //    new Sculpture(4, "Mindetavle for Københavns belejring 1658 - 60", "Bygning", "Stormgade",
            //        "På Nationalmuseets mur under søjlegalleriet mod Vester Voldgade", "NULL", "NULL"),
            //    new Sculpture(5, "Maleren Asmus Jacob Carstens", "Jord", "Glyptotekets anlæg", "Ved Niels Brocksgade",
            //        "NULL", "NULL")
            //};

            Sculptures = await new PersistenceFacade().GetAllSculptures();
            // Here we get all the types and materials for each sculpture and store them in two separate collections.
            foreach (var sculpture in Sculptures)
            {
                sculpture.SculptureTypes = await new PersistenceFacade().GetSculptureTypesAsync(sculpture.ID);
                //sculpture.SculptureMaterials = await new PersistenceFacade().GetSculptureMaterialsAsync(sculpture.ID);
            }

        }
    }
}