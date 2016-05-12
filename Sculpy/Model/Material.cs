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

        public Material(string materialName)
        {
            // TODO Dani: create MaterialController and go through the collection and extract the material.
            if (materialName == "Bronze")
            {
                this.ID = 21;
                this.Material_Type_ID = 2;
                this.Material_Name = materialName;
            }
        }

    }
}
