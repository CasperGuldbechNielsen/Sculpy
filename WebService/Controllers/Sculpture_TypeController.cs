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
    public class Sculpture_TypeController : ApiController
    {
        private SculptureContext db = new SculptureContext();

        // GET: api/Sculpture_Type
        public IQueryable<Sculpture_Type> GetSculpture_Type()
        {
            return db.Sculpture_Type;
        }

        // GET: api/Sculpture_Type/5
        [ResponseType(typeof(Sculpture_Type))]
        public IHttpActionResult GetSculpture_Type(int id)
        {
            Sculpture_Type sculpture_Type = db.Sculpture_Type.Find(id);
            if (sculpture_Type == null)
            {
                return NotFound();
            }

            return Ok(sculpture_Type);
        }

        // PUT: api/Sculpture_Type/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSculpture_Type(int id, Sculpture_Type sculpture_Type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sculpture_Type.ID)
            {
                return BadRequest();
            }

            db.Entry(sculpture_Type).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Sculpture_TypeExists(id))
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

        // POST: api/Sculpture_Type
        [ResponseType(typeof(Sculpture_Type))]
        public IHttpActionResult PostSculpture_Type(Sculpture_Type sculpture_Type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sculpture_Type.Add(sculpture_Type);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sculpture_Type.ID }, sculpture_Type);
        }

        // DELETE: api/Sculpture_Type/5
        [ResponseType(typeof(Sculpture_Type))]
        public IHttpActionResult DeleteSculpture_Type(int id)
        {
            Sculpture_Type sculpture_Type = db.Sculpture_Type.Find(id);
            if (sculpture_Type == null)
            {
                return NotFound();
            }

            db.Sculpture_Type.Remove(sculpture_Type);
            db.SaveChanges();

            return Ok(sculpture_Type);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Sculpture_TypeExists(int id)
        {
            return db.Sculpture_Type.Count(e => e.ID == id) > 0;
        }
    }
}