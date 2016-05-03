using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebService;

namespace WebService.Controllers
{
    public class MaterialsController : ApiController
    { 
        private SculptureContext db = new SculptureContext();

        // GET: api/Materials
        public IQueryable<Material> GetMaterials()
        {
            return db.Materials.Include(s=>s.Sculpture_Material);
        }

        // GET: api/Materials/5
        [ResponseType(typeof(Material))]
        public IHttpActionResult GetMaterial(int id)
        {
            Material material = db.Materials.Find(id);
            if (material == null)
            {
                return NotFound();
            }

            return Ok(material);
        }

        // PUT: api/Materials/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMaterial(int id, Material material)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != material.ID)
            {
                return BadRequest();
            }

            db.Entry(material).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaterialExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Materials
        [ResponseType(typeof(Material))]
        public IHttpActionResult PostMaterial(Material material)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Materials.Add(material);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = material.ID }, material);
        }

        // DELETE: api/Materials/5
        [ResponseType(typeof(Material))]
        public IHttpActionResult DeleteMaterial(int id)
        {
            Material material = db.Materials.Find(id);
            if (material == null)
            {
                return NotFound();
            }

            db.Materials.Remove(material);
            db.SaveChanges();

            return Ok(material);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MaterialExists(int id)
        {
            return db.Materials.Count(e => e.ID == id) > 0;
        }
    }
}