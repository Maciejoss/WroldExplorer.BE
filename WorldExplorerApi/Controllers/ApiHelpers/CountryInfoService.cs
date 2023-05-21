using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Web.Http;
using WorldExplorerApi.Models.Country;

namespace WorldExplorerApi.Controllers.ApiHelpers
{
    public class CountryInfoService
    {
        private string _baseUrl { get; set; }

        public CountryInfoService(IConfiguration configuration)
        {
            _baseUrl = configuration.GetSection("DataApisUrls").GetValue<string>("CountriesInfoUrl");
        }

        public async Task<List<CountryInfo>> SelectRandomCountriesInfos(List<Country> inputList, int count)
        {
            bool locked = false;
            if (inputList.Count < count) { count = inputList.Count; locked = true; }

            Random random = new Random();
            List<CountryInfo> randomItems = new List<CountryInfo>(count);
            List<Country> items = new List<Country>(inputList);

            for (int i = 0; i < count; i++)
            {
                int randomIndex = random.Next(i, items.Count);
                CountryInfo randomInfo = await GetCountryInfo(items[randomIndex].Name);
                items[randomIndex] = items[i];
                if (randomInfo.OfficialName != null) randomItems.Add(randomInfo);
                else if (!locked) { i--; }
            }
            return randomItems;
        }

        public async Task<CountryInfo> GetCountryInfo(string countryName)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(_baseUrl + countryName);
                if(!response.IsSuccessStatusCode) {
                    return new CountryInfo(new JObject());
                }
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                JArray jsonArray = JArray.Parse(responseBody);
                JObject? jObject = jsonArray.First as JObject;

                CountryInfo countryInfo;

                if (jObject == null) throw new Exception("Couldn't retrive info");

                countryInfo = new CountryInfo(jObject);

                return countryInfo;
            }

        }
    }
}
