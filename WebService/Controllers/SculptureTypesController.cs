using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebService.Controllers
{
    public class SculptureTypesController : ApiController
    {
        SculptureContext db = new SculptureContext();

        [Route("api/SculptureTypes/{Sculpture_Id:int}")]
        [HttpGet]
        [ResponseType(typeof(string))]
        public IQueryable<string> GetAllSculptureTypes(int sculpture_Id)
        {
            var query1 =
                from st in db.Sculpture_Type_Linking
                from t in db.Sculpture_Type
                where st.Sculpture_Type_ID == t.ID
                select new
                {
                    SculptureId = st.Sculpture_ID,
                    SculptureType = t.Sculpture_Type1
                };

            var query2 =
                from t in query1
                where t.SculptureId == sculpture_Id
                select t.SculptureType;

            return query2;
        }

        [Route("api/UpdateSculptureTypes/{sculptureId:int}")]
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateSculptureTypes(int sculptureId, List<int> tyesIds)
        {
            var collection = new List<Sculpture_Type_Linking>();
            if (db.Sculpture_Type_Linking != null && db.Sculpture_Type_Linking.Any())
            {
                collection = db.Sculpture_Type_Linking.Where(st => st.Sculpture_ID == sculptureId).ToList();

            }
            if (collection.Count() != 0)
            {
                foreach (var entry in collection)
                {
                    db.Sculpture_Type_Linking.Remove(entry);
                }
                db.SaveChanges();
            }

            const string sql = "INSERT INTO Sculpture_Type_Linking(Sculpture_ID, Sculpture_Type_ID) VALUES(@P0, @P1)";
            var parameterList = new List<object>();
            foreach (var typeId in tyesIds)
            {
                parameterList.Add(sculptureId);
                parameterList.Add(typeId);
                var parameters1 = parameterList.ToArray();
                db.Database.ExecuteSqlCommand(sql, parameters1);
                parameterList.Clear();
            }
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
