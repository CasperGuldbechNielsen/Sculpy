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

        //TODO this is not working because I don't know te type of the response.
        [Route("api/SculptureTypes")]
        [HttpGet]
        [ResponseType(typeof(object))]
        public IQueryable<object> GetAllSculptureTypes()
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

            var dictionary = new Dictionary<int,string>();

            foreach (var obj in query1)
            {
                dictionary.Add(obj.SculptureId,obj.SculptureType);
            }


            return query1;
        }


    }
}
