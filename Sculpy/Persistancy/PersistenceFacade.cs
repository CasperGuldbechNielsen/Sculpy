using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using Windows.UI.Popups;
using Windows.Web.Http;
using Sculpy.Model;

namespace Sculpy.Persistancy
{
    /// <summary>
    /// This class handles all the communication with the WebService 
    /// to connect to the database
    /// </summary>
    public class PersistenceFacade
    {

        private const string ServerUrl = "http://localhost:57671";
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
            using (var client = new System.Net.Http.HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = client.GetAsync("api/Sculptures").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var sculptureList = response.Content.ReadAsAsync<IEnumerable<Sculpture>>().Result;
                        return sculptureList.ToList();
                    }

                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
                return null;
            }
        }

        /// <summary>
        /// This method contacst the database and retrieves all inspections
        /// </summary>
        /// <returns>A list of inspections</returns>
        public List<Inspection> GetAllInspections()
        {
            using (var client = new System.Net.Http.HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = client.GetAsync("api/Inspections").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var inspectionList = response.Content.ReadAsAsync<IEnumerable<Inspection>>().Result;
                        return inspectionList.ToList();
                    }

                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
                return null;
            }
        }
    }
}