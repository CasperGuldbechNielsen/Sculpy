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
    public class Sculpture_Type_LinkingController : ApiController
    {
        private SculptureContext db = new SculptureContext();

        // GET: api/Sculpture_Type_Linking
        public IQueryable<Sculpture_Type_Linking> GetSculpture_Type_Linking()
        {
            return db.Sculpture_Type_Linking;
        }

        // GET: api/Sculpture_Type_Linking/5
        [ResponseType(typeof(Sculpture_Type_Linking))]
        public IHttpActionResult GetSculpture_Type_Linking(int id)
        {
            Sculpture_Type_Linking sculpture_Type_Linking = db.Sculpture_Type_Linking.Find(id);
            if (sculpture_Type_Linking == null)
            {
                return NotFound();
            }

            return Ok(sculpture_Type_Linking);
        }

        // PUT: api/Sculpture_Type_Linking/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSculpture_Type_Linking(int id, Sculpture_Type_Linking sculpture_Type_Linking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sculpture_Type_Linking.Sculpture_ID)
            {
                return BadRequest();
            }

            db.Entry(sculpture_Type_Linking).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Sculpture_Type_LinkingExists(id))
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

        // POST: api/Sculpture_Type_Linking
        [ResponseType(typeof(Sculpture_Type_Linking))]
        public IHttpActionResult PostSculpture_Type_Linking(Sculpture_Type_Linking sculpture_Type_Linking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sculpture_Type_Linking.Add(sculpture_Type_Linking);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Sculpture_Type_LinkingExists(sculpture_Type_Linking.Sculpture_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sculpture_Type_Linking.Sculpture_ID }, sculpture_Type_Linking);
        }

        // DELETE: api/Sculpture_Type_Linking/5
        [ResponseType(typeof(Sculpture_Type_Linking))]
        public IHttpActionResult DeleteSculpture_Type_Linking(int id)
        {
            Sculpture_Type_Linking sculpture_Type_Linking = db.Sculpture_Type_Linking.Find(id);
            if (sculpture_Type_Linking == null)
            {
                return NotFound();
            }

            db.Sculpture_Type_Linking.Remove(sculpture_Type_Linking);
            db.SaveChanges();

            return Ok(sculpture_Type_Linking);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Sculpture_Type_LinkingExists(int id)
        {
            return db.Sculpture_Type_Linking.Count(e => e.Sculpture_ID == id) > 0;
        }
    }
}