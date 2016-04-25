using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Sculpy.Model;

namespace Sculpy.Persistancy
{
    /// <summary>
    /// This class handles all the communication with the WebService 
    /// to connect to the database
    /// </summary>
    public class PersistenceFacade
    {

        private const string ServerUrl = "http://sculpywebapi.azurewebsites.net";
        private readonly HttpClientHandler handler;

        public PersistenceFacade()
        {
            handler = new HttpClientHandler {UseDefaultCredentials = true};
        }

        /// <summary>
        /// This method contacts the database and retrieves all sculptures in the database
        /// </summary>
        /// <returns>A list of sculptures</returns>
        public async Task<ObservableCollection<Sculpture>> GetAllSculptures()
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = client.GetAsync("api/Sculptures").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var hotelList = await response.Content.ReadAsAsync<ObservableCollection<Sculpture>>();
                        return hotelList;
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