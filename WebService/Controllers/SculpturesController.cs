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
    public class SculpturesController : ApiController
    {
        private SculptureContext db = new SculptureContext();

        // GET: api/Sculptures
        public IQueryable<Sculpture> GetSculptures()
        {
            return db.Sculptures;
        }

        // GET: api/Sculptures/5
        [ResponseType(typeof(Sculpture))]
        public IHttpActionResult GetSculpture(int id)
        {
            Sculpture sculpture = db.Sculptures.Find(id);
            if (sculpture == null)
            {
                return NotFound();
            }

            return Ok(sculpture);
        }

        // PUT: api/Sculptures/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSculpture(int id, Sculpture sculpture)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sculpture.ID)
            {
                return BadRequest();
            }

            db.Entry(sculpture).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SculptureExists(id))
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

        // POST: api/Sculptures
        [ResponseType(typeof(Sculpture))]
        public IHttpActionResult PostSculpture(Sculpture sculpture)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sculptures.Add(sculpture);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sculpture.ID }, sculpture);
        }

        // DELETE: api/Sculptures/5
        [ResponseType(typeof(Sculpture))]
        public IHttpActionResult DeleteSculpture(int id)
        {
            Sculpture sculpture = db.Sculptures.Find(id);
            if (sculpture == null)
            {
                return NotFound();
            }

            db.Sculptures.Remove(sculpture);
            db.SaveChanges();

            return Ok(sculpture);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SculptureExists(int id)
        {
            return db.Sculptures.Count(e => e.ID == id) > 0;
        }
    }
}