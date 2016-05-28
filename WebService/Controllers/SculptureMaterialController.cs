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
        private readonly SculptureContext _db = new SculptureContext();

        /// <summary>
        /// This Action gets all the materials related to a specific sculpture.
        /// </summary>
        /// <param name="sculpture_Id">This parameter represents the ID of the sculpture for which we want the materials.</param>
        /// <returns>It returns the list of all the materials associated to that Sculpture.</returns>
        [Route("api/SculptureMaterials/{Sculpture_Id:int}")]
        [HttpGet]
        [ResponseType(typeof(Material))]
        public IQueryable<Material> GetAllSculptureMaterials(int sculpture_Id)
        {
            var query =
                from sm in _db.Sculpture_Material
                where sm.Sculpture_ID == sculpture_Id
                select sm.Material;
            // db.Sculptures.Include(s=>s.)
            return query;
        }

        /// <summary>
        /// This Action updates all the materials related to a specific sculpture.
        /// </summary>
        /// <param name="sculptureId">This parameter represents the ID of the sculpture for which we want to update the materials.</param>
        /// <param name="materialIds">This parameter contains all the IDs of the materials that are owned by the sculpture.</param>
        /// <returns></returns>
        [Route("api/UpdateSculptureMaterials/{sculptureId:int}")]
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateSculptureMaterials(int sculptureId, List<int> materialIds)
        {
            var collection = new List<Sculpture_Material>();
            if (_db.Sculpture_Material != null && _db.Sculpture_Material.Any())
            {
                collection = _db.Sculpture_Material.Where(sm => sm.Sculpture_ID == sculptureId).ToList();
            }
            
            if (collection.Count() != 0)
            {
                foreach (var entry in collection)
                {
                    _db.Sculpture_Material.Remove(entry);
                }
                _db.SaveChanges();
            }

            const string sql = "INSERT INTO Sculpture_Material(Sculpture_ID, Material_ID) VALUES(@P0, @P1)";
            var parameterList = new List<object>();
            foreach (var materialId in materialIds)
            {
                parameterList.Add(sculptureId);
                parameterList.Add(materialId);
                var parameters1 = parameterList.ToArray();
                _db.Database.ExecuteSqlCommand(sql, parameters1);
                parameterList.Clear();
            }
            _db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// This Action adds all the materials for a specific sculpture. 
        /// </summary>
        /// <param name="sculptureId">This parameter represents the ID of the sculpture for which we want to update the materials.</param>
        /// <param name="materialIds">This parameter contains all the IDs of the materials that are owned by the sculpture.</param>
        /// <returns></returns>
        [Route("api/CreateSculptureMaterials/{sculptureId:int}")]
        [HttpPost]
        [ResponseType(typeof(void))]
        public IHttpActionResult CreateSculptureMaterials(int sculptureId, List<int> materialIds)
        {
            const string sql = "INSERT INTO Sculpture_Material(Sculpture_ID, Material_ID) VALUES(@P0, @P1)";
            var parameterList = new List<object>();
            foreach (var materialId in materialIds)
            {
                parameterList.Add(sculptureId);
                parameterList.Add(materialId);
                var parameters1 = parameterList.ToArray();
                _db.Database.ExecuteSqlCommand(sql, parameters1);
                parameterList.Clear();
            }
            _db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// This Action deletes all the materials for a specific sculpture.
        /// </summary>
        /// <param name="sculptureId">It's required to have only the ID of the sculpture.</param>
        /// <returns></returns>
        [Route("api/DeleteSculptureMaterials/{sculptureId:int}")]
        [HttpDelete]
        [ResponseType(typeof (void))]
        public IHttpActionResult DeleteSculptureMaterials(int sculptureId)
        {
            foreach (var material in _db.Sculpture_Material.Where(material => material.Sculpture_ID == sculptureId))
            {
                _db.Sculpture_Material.Remove(material);
            }
            _db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
