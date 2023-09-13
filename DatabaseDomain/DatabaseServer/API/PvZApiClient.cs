using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DatabaseDomain;
using Newtonsoft.Json;


namespace DatabaseServer
{

    public class PvZApiClient
    {
        private HttpClient _httpClient;
        private string _baseUrl;

        public PvZApiClient(string apiUrl)
        {
            _httpClient = new HttpClient();
            _baseUrl = apiUrl;
        }

        public async Task<Plant[]> CreateAllPlantsAsync()
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/plants");

            var plantNamesJson = await response.Content.ReadAsStringAsync();
            var plantNames = JsonConvert.DeserializeObject<string[]>(plantNamesJson);


            var plantCount = plantNames.Length;
            var plants = new Plant[plantCount];

            for (int plantIndex = 0; plantIndex < plantCount; plantIndex++)
            {
                var plantName = plantNames[plantIndex];
                plantName = plantName.Replace("\"", "");
                plants[plantIndex] = await CreatePlantAsync(plantName);
            }



            return plants;
        }


        public async Task<Plant> CreatePlantAsync(string plantName)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/plants/{plantName}");

            var plantJson = await response.Content.ReadAsStringAsync();
            var plant = JsonConvert.DeserializeObject<Plant>(plantJson);

            return plant;
        }
    }

}
