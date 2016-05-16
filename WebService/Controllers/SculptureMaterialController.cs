using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Description;
using WebGrease.Css.Extensions;

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


        [Route("api/UpdateSculptureMaterials/{sculptureId:int}")]
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateSculptureMaterials(int sculptureId, List<int> materialIds)
        {
            var collection = db.Sculpture_Material.Where(sm => sm.Sculpture_ID == sculptureId);
            foreach (var entry in collection)
            {
                db.Sculpture_Material.Remove(entry);
            }
            db.SaveChanges();

            const string sql = "INSERT INTO Sculpture_Material(Sculpture_ID, Material_ID) VALUES(@P0, @P1)";
            var parameterList = new List<object>();
            foreach (var materialId in materialIds)
            {
                parameterList.Add(sculptureId);
                parameterList.Add(materialId);
                var parameters1 = parameterList.ToArray();
                db.Database.ExecuteSqlCommand(sql, parameters1);
                parameterList.Clear();
            }
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        
    }
}
