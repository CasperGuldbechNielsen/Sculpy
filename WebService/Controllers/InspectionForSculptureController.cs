using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebService.Controllers
{
    public class InspectionForSculptureController : ApiController
    {
        SculptureContext db = new SculptureContext();

        /// <summary>
        /// This Action creates a new inspection.
        /// </summary>
        /// <param name="sculptureId">We pass the ID of the Sculpture for which we want to create a new inspection.</param>
        /// <param name="inspection">This parameter holds the values for the inspection which is going to be created.</param>
        /// <returns></returns>
        [Route("api/CreateInspectionForSculpture/{sculptureId:int}")]
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult CreateInspectionForSculpture(int sculptureId, Inspection inspection)
        {
            db.Inspections.Add(inspection);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// This Action deletes all the inspections for a specific sculpture.
        /// </summary>
        /// <param name="sculptureId">We need to pass only the ID of the sculpture.</param>
        /// <returns></returns>
        [Route("api/DeleteInspectionForSculpture/{sculptureId:int}")]
        [HttpDelete]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteInspectionForSculpture(int sculptureId)
        {
            foreach (var insp in db.Inspections.Where(inspection => inspection.Sculpture_ID == sculptureId))
            {
                db.Inspections.Remove(insp);
            }
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
