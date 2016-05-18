﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Metadata;
using Windows.UI.Popups;
using Newtonsoft.Json;
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
            handler = new HttpClientHandler { UseDefaultCredentials = true };
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

        public async Task<Sculpture> GetOnlyOneSculptures(int sculptureId)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = client.GetAsync($"api/Sculptures/{sculptureId}").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var sculpture = await response.Content.ReadAsAsync<Sculpture>();
                        return sculpture;
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

        public async Task CreateSculptureAsync(Sculpture sculpture)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = JsonConvert.SerializeObject(sculpture);
                var sculptureContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                try
                {
                    var response = await client.PostAsync("Api/Sculptures", sculptureContent);
                }
                catch (Exception ex)
                {
                    await new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }

        public async Task DeleteSculptureAsync(int id)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.DeleteAsync("api/Sculptures/" + id);
                }
                catch (Exception ex)
                {
                    await new MessageDialog(ex.Message).ShowAsync();
                }

            }
        }

        public async Task UpdateSculptureAsync(Sculpture sculpture)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json= JsonConvert.SerializeObject(sculpture);

                var content = new StringContent(json, Encoding.UTF8, "Application/json");

                try
                {
                    var updateResponse = await client.PutAsync("api/Sculptures/" + sculpture.ID, content);
                }
                catch (Exception ex)
                {
                    await new MessageDialog(ex.Message).ShowAsync();
                }
                

            }
        }

        public async Task<List<Material>> GetAllMaterials()
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = client.GetAsync("api/Materials").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var materialList = await response.Content.ReadAsAsync<List<Material>>();
                        return materialList;
                    }

                }
                catch (Exception ex)
                {
                    await new MessageDialog(ex.Message).ShowAsync();
                }
                return null;
            }
        }

        public async Task UpdateSculptureMaterialsAsync(int sculptureId, List<int> materialIds)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = JsonConvert.SerializeObject(materialIds);

                var content = new StringContent(json, Encoding.UTF8, "Application/json");

                try
                {
                    var updateResponse = await client.PutAsync("api/UpdateSculptureMaterials/" + sculptureId, content);
                }
                catch (Exception ex)
                {
                    await new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }

        public async Task CreateSculptureMaterialsAsync(int sculptureId, List<int> materialIds)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = JsonConvert.SerializeObject(materialIds);

                var content = new StringContent(json, Encoding.UTF8, "Application/json");

                try
                {
                    var updateResponse = await client.PostAsync("api/CreateSculptureMaterials/" + sculptureId, content);
                }
                catch (Exception ex)
                {
                    await new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }

        public async Task UpdateSculptureTypesAsync(int sculptureId, List<int> typeIds)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = JsonConvert.SerializeObject(typeIds);

                var content = new StringContent(json, Encoding.UTF8, "Application/json");

                try
                {
                    var updateResponse = await client.PutAsync("api/UpdateSculptureTypes/" + sculptureId, content);
                }
                catch (Exception ex)
                {
                    await new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }

        public async Task CreateInspectionAsync(Inspection inspection)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = JsonConvert.SerializeObject(inspection);
                var inspectionContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                try
                {
                    var response = await client.PutAsync($"Api/CreateInspectionForSculpture/{inspection.Sculpture_ID}", inspectionContent);
                }
                catch (Exception ex)
                {
                    await new MessageDialog(ex.Message).ShowAsync();
                }
            }

            
        }

        public async Task UpdateEditedInspection(Inspection inspection)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = JsonConvert.SerializeObject(inspection);
                var inspectionContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                try
                {
                    var response = await client.PutAsync("api/Inspections/" + inspection.ID, inspectionContent);
                }
                catch (Exception ex)
                {

                    await new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }
    }  
}