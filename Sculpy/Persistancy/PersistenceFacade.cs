﻿using System;
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

        private const string ServerUrl = "http://skulpywebapi.azurewebsites.net";
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
                    await new MessageDialog(ex.Message).ShowAsync();
                }
                return null;
            }
        }

        public async Task<List<Inspection>> GetInspetionsFromSelectedSculpture(int sculptureId)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = client.GetAsync($"api/Inspections?$filter=Sculpture_ID eq {sculptureId}").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var inspectionList = await response.Content.ReadAsAsync<IEnumerable<Inspection>>();

                        return inspectionList.ToList();
                    }
                }
                catch (Exception ex)
                {
                    await new MessageDialog(ex.Message).ShowAsync();
                }

                return null;
            }
        }

        public async Task<List<string>> GetSculptureTypesAsync(int sculptureId)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = client.GetAsync($"api/SculptureTypes/{sculptureId}").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var typesList = await response.Content.ReadAsAsync<IEnumerable<string>>();

                        return typesList.ToList();
                    }
                }
                catch (Exception ex)
                {
                    await new MessageDialog(ex.Message).ShowAsync();
                }

                return null;
            }
        }

        public async Task<List<Material>> GetSculptureMaterialsAsync(int sculptureId)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = client.GetAsync($"api/SculptureMaterials/{sculptureId}").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var materialList = await response.Content.ReadAsAsync<IEnumerable<Material>>();

                        return materialList.ToList();
                    }
                }
                catch (Exception ex)
                {
                    await new MessageDialog(ex.Message).ShowAsync();
                }

                return null;
            }
        }


        /// <summary>
        /// Retrieve all inspections in the database
        /// </summary>
        /// <returns>ObservableCollection of Inspections</returns>
        public async Task<ObservableCollection<Inspection>> GetAllInspections()
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = client.GetAsync("api/Inspections").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var inspectionList = await response.Content.ReadAsAsync<ObservableCollection<Inspection>>();
                        return inspectionList;
                    }

                }
                catch (Exception ex)
                {
                    await new MessageDialog(ex.Message).ShowAsync();
                }
                return null;
            }
        }
    }
}