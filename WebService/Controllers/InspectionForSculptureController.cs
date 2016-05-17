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

        [Route("api/CreateInspectionForSculpture/{sculptureId:int}")]
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult CreateInspectionForSculpture(int sculptureId, Inspection inspection)
        {
          
            inspection.Sculpture_ID = sculptureId;
            inspection.ID = 23;
            inspection.Inspection_Date = DateTime.Now;
            db.Inspections.Add(inspection);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
