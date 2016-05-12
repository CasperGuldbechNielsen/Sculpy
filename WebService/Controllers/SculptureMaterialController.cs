using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebService.Controllers
{
    public class SculptureMaterialController : ApiController
    {
        SculptureContext db = new SculptureContext();

        [Route("api/SculptureMaterials/{Sculpture_Id:int}")]
        [HttpGet]
        [ResponseType(typeof(Material))]
        public IQueryable<Material> GetAllSculptureMaterials(int sculpture_Id)
        {  
            var query =
                from sm in db.Sculpture_Material
                where sm.Sculpture_ID == sculpture_Id
                select sm.Material;
            // db.Sculptures.Include(s=>s.)
            return query;
        }
    }
}
