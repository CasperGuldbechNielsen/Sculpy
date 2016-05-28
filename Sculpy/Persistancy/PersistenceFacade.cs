using System;
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
    /// This class handles the entire communication with the WebService in order to operate on the Database.
    /// </summary>
    public class PersistenceFacade
    {
        /// <summary>
        /// This field hold the URL conncetion to the Web Service.
        /// </summary>
        private const string ServerUrl = "http://skulpywebapi.azurewebsites.net";
        private readonly HttpClientHandler _handler;

        public PersistenceFacade()
        {
            _handler = new HttpClientHandler { UseDefaultCredentials = true };
        }

        /// <summary>
        /// This method contacts the database and retrieves all sculptures in the database
        /// </summary>
        /// <returns>A list of sculptures</returns>
        public async Task<ObservableCollection<Sculpture>> GetAllSculptures()
        {
            using (var client = new HttpClient(_handler))
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

        /// <summary>
        /// This method requests the Web Service for a single sculpture.
        /// </summary>
        /// <param name="sculptureId">The Id of the desired sculpture has to be known.</param>
        /// <returns></returns>
        public async Task<Sculpture> GetOnlyOneSculptures(int sculptureId)
        {
            using (var client = new HttpClient(_handler))
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

        /// <summary>
        /// This method sends a request to the WebService in order to get all the inspections associated with a sculpture.
        /// </summary>
        /// <param name="sculptureId">That specific scultpure is recognize by the passed ID.</param>
        /// <returns>It returns all the inspections related to a specific sculpture.</returns>
        public async Task<List<Inspection>> GetInspetionsFromSelectedSculpture(int sculptureId)
        {
            using (var client = new HttpClient(_handler))
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

        /// <summary>
        /// This method gets all the types of a specific sculpture.
        /// </summary>
        /// <param name="sculptureId">It requires only the ID of that specific sculpture.</param>
        /// <returns>It returns the list of all the types of that sculpture.</returns>
        public async Task<List<string>> GetSculptureTypesAsync(int sculptureId)
        {
            using (var client = new HttpClient(_handler))
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

        /// <summary>
        /// This method gets all the materials of a specific sculpture.
        /// </summary>
        /// <param name="sculptureId">It requires only the ID of that specific sculpture.</param>
        /// <returns>It returns the list of all the materials of that sculpture.</returns>
        public async Task<List<Material>> GetSculptureMaterialsAsync(int sculptureId)
        {
            using (var client = new HttpClient(_handler))
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
            using (var client = new HttpClient(_handler))
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

        /// <summary>
        /// This method is called whenver the user creates a new sculpture.
        /// </summary>
        /// <param name="sculpture">This parameter holds all the information about the new created sculpture which is going to be inserted into the Database.</param>
        /// <returns></returns>
        public async Task CreateSculptureAsync(Sculpture sculpture)
        {
            using (var client = new HttpClient(_handler))
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

        /// <summary>
        /// This method is called whenver the user deletes an existing sculpture.
        /// </summary>
        /// <param name="id">It's required only the ID of hte suclpture for this operation.</param>
        /// <returns></returns>
        public async Task DeleteSculptureAsync(int id)
        {
            using (var client = new HttpClient(_handler))
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

        /// <summary>
        /// This method is called whenver the user edits an existing sculpture.
        /// </summary>
        /// <param name="sculpture">This parameter holds all the information about the modified sculpture which is going to be updated in the Database.</param>
        /// <returns></returns>
        public async Task UpdateSculptureAsync(Sculpture sculpture)
        {
            using (var client = new HttpClient(_handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = JsonConvert.SerializeObject(sculpture);

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

        /// <summary>
        /// This method gets all the available Materials from the Database.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Material>> GetAllMaterials()
        {
            using (var client = new HttpClient(_handler))
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

        /// <summary>
        /// This method gets all the available Sculpture Types from the Database.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Sculpture_Type>> GetAllSculptureTypes()
        {
            using (var client = new HttpClient(_handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = client.GetAsync("api/Sculpture_Type").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var list = await response.Content.ReadAsAsync<List<Sculpture_Type>>();
                        return list;
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
        /// This method updates the materials of a specific sculpture when the user chooses to update a sculpture.
        /// </summary>
        /// <param name="sculptureId">This operation requires the ID of the Sculpture.</param>
        /// <param name="materialIds">This parameter holds all the IDs of the materials which that sculpture has.</param>
        /// <returns></returns>
        public async Task UpdateSculptureMaterialsAsync(int sculptureId, List<int> materialIds)
        {
            using (var client = new HttpClient(_handler))
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

        /// <summary>
        /// This method sends a request to the Database to add all the materials for a new created sculpture.
        /// </summary>
        /// <param name="sculptureId">This operation requires the ID of the Sculpture.</param>
        /// <param name="materialIds">This parameter contains all the IDs of the materials associated to this specific sculpture.</param>
        /// <returns></returns>
        public async Task CreateSculptureMaterialsAsync(int sculptureId, List<int> materialIds)
        {
            using (var client = new HttpClient(_handler))
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

        /// <summary>
        /// This method updates the types of a specific sculpture when the user chooses to update a sculpture.
        /// </summary>
        /// <param name="sculptureId">This operation requires the ID of the Sculpture.</param>
        /// <param name="typeIds">This parameter holds all the IDs of the types which that sculpture is.</param>
        /// <returns></returns>
        public async Task UpdateSculptureTypesAsync(int sculptureId, List<int> typeIds)
        {
            using (var client = new HttpClient(_handler))
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

        /// <summary>
        /// This method is called whenver a new inspection is going to be created.
        /// </summary>
        /// <param name="inspection">This parameter holds the values of the new created inspection.</param>
        /// <returns></returns>
        public async Task CreateInspectionAsync(Inspection inspection)
        {
            using (var client = new HttpClient(_handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = JsonConvert.SerializeObject(inspection);
                var inspectionContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                try
                {
                    var response =
                        await
                            client.PutAsync($"Api/CreateInspectionForSculpture/{inspection.Sculpture_ID}",
                                inspectionContent);
                }
                catch (Exception ex)
                {
                    await new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }

        /// <summary>
        /// Through this method an existing inspection is able to be edited and updated inside the Database.
        /// </summary>
        /// <param name="inspection">We are passing the related details for updating the inspection in the database.</param>
        /// <returns></returns>
        public async Task UpdateEditedInspection(Inspection inspection)
        {
            using (var client = new HttpClient(_handler))
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

        /// <summary>
        /// By calling this method a specific inspection is going to be deleted. 
        /// </summary>
        /// <param name="id">We are passing the ID of the inspection.</param>
        /// <returns></returns>
        public async Task DeleteInspectionAsync(int id)
        {
            using (var client = new HttpClient(_handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.DeleteAsync("api/Inspections/" + id);
                }
                catch (Exception ex)
                {
                    await new MessageDialog(ex.Message).ShowAsync();
                }

            }
        }

        /// <summary>
        /// This method is called when a sculpture is deleted in order to remove any reference from the Database of a sculpture before we delete it.
        /// </summary>
        /// <param name="id">This parameter holds the value of the Sculpture which is going to be deleted.</param>
        /// <returns></returns>
        public async Task DeleteSculptureTypesAsync(int id)
        {
            using (var client = new HttpClient(_handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.DeleteAsync("api/DeleteSculptureTypes/" + id);
                }
                catch (Exception ex)
                {
                    await new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }

        /// <summary>
        /// This method is called when a sculpture is deleted in order to remove any reference from the Database of a sculpture before we delete it.
        /// </summary>
        /// <param name="id">This parameter holds the value of the Sculpture which is going to be deleted.</param>
        /// <returns></returns>
        public async Task DeleteSculptureMaterialsAsync(int id)
        {
            using (var client = new HttpClient(_handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.DeleteAsync("api/DeleteSculptureMaterials/" + id);
                }
                catch (Exception ex)
                {
                    await new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }

        /// <summary>
        /// This method is called when a sculpture is deleted in order to remove any reference from the Database of a sculpture before we delete it.
        /// </summary>
        /// <param name="id">This parameter holds the value of the Sculpture which is going to be deleted.</param>
        /// <returns></returns>
        public async Task DeleteSculptureInspectionsAsync(int id)
        {
            using (var client = new HttpClient(_handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.DeleteAsync("api/DeleteInspectionForSculpture/" + id);
                }
                catch (Exception ex)
                {
                    await new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }
    }
}