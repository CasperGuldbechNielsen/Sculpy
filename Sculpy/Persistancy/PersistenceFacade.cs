using System.Collections.Generic;
using System.Net.Http;
using Sculpy.Model;

namespace Sculpy.Persistancy
{
    /// <summary>
    /// This class handles all the communication with the WebService 
    /// to connect to the database
    /// </summary>
    public class PersistenceFacade
    {

        private const string ServerUrl = "http://localhost:50000";
        private HttpClientHandler handler;

        public PersistenceFacade()
        {
            handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
        }

        /// <summary>
        /// This method contacts the database and retrieves all sculptures in the database
        /// </summary>
        /// <returns>A list of sculptures</returns>
        public List<Sculpture> GetAllSculptures()
        {
            return null;
        }
    }
}