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
        private readonly SculptureContext _db = new SculptureContext();

        /// <summary>
        /// This Action gets all the types related to a specific sculpture.
        /// </summary>
        /// <param name="sculpture_Id">This parameter represents the ID of the sculpture for which we want the types.</param>
        /// <returns></returns>
        [Route("api/SculptureTypes/{Sculpture_Id:int}")]
        [HttpGet]
        [ResponseType(typeof(string))]
        public IQueryable<string> GetAllSculptureTypes(int sculpture_Id)
        {
            var query1 =
                from st in _db.Sculpture_Type_Linking
                from t in _db.Sculpture_Type
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

        /// <summary>
        /// This Action updates all the types related to a specific sculpture.
        /// </summary>
        /// <param name="sculptureId">This parameter represents the ID of the sculpture for which we want to update the types.</param>
        /// <param name="tyesIds">This parameter contains all the IDs of the types that are of that sculpture.</param>
        /// <returns></returns>
        [Route("api/UpdateSculptureTypes/{sculptureId:int}")]
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateSculptureTypes(int sculptureId, List<int> tyesIds)
        {
            var collection = new List<Sculpture_Type_Linking>();
            if (_db.Sculpture_Type_Linking != null && _db.Sculpture_Type_Linking.Any())
            {
                collection = _db.Sculpture_Type_Linking.Where(st => st.Sculpture_ID == sculptureId).ToList();

            }
            if (collection.Count() != 0)
            {
                foreach (var entry in collection)
                {
                    _db.Sculpture_Type_Linking.Remove(entry);
                }
                _db.SaveChanges();
            }

            const string sql = "INSERT INTO Sculpture_Type_Linking(Sculpture_ID, Sculpture_Type_ID) VALUES(@P0, @P1)";
            var parameterList = new List<object>();
            foreach (var typeId in tyesIds)
            {
                parameterList.Add(sculptureId);
                parameterList.Add(typeId);
                var parameters1 = parameterList.ToArray();
                _db.Database.ExecuteSqlCommand(sql, parameters1);
                parameterList.Clear();
            }
            _db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// This Action deletes all the types related to a specific sculpture.
        /// </summary>
        /// <param name="sculptureId">It's required to have only the ID of the sculpture.</param>
        /// <returns></returns>
        [Route("api/DeleteSculptureTypes/{sculptureId:int}")]
        [HttpDelete]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteSculptureTypes(int sculptureId)
        {
            foreach (var type in _db.Sculpture_Type_Linking.Where(type => type.Sculpture_ID == sculptureId))
            {
                _db.Sculpture_Type_Linking.Remove(type);
            }
            _db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
