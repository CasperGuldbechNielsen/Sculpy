using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sculpy.Model
{
    public class Material
    {
        public int ID { get; set; }

        public string Material_Name { get; set; }

        public int Material_Type_ID { get; set; }

        public Material()
        {

        }
        public Material(string materialName)
        {
            var materialList = new Persistancy.PersistenceFacade().GetAllMaterials().Result;

            foreach (var material in materialList.Where(material => materialName == material.Material_Name))
            {
                this.ID = material.ID;
                this.Material_Type_ID = material.Material_Type_ID;
                this.Material_Name = materialName;
                break;
            }
        }
    }
}
