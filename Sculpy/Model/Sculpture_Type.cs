using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sculpy.Model
{
    class Sculpture_Type
    {
        public int ID { get; set; }

        public string Sculpture_Type1 { get; set; }

        public Sculpture_Type(int id, string sculptureType1)
        {
            ID = id;
            Sculpture_Type1 = sculptureType1;
        }

    }
}
