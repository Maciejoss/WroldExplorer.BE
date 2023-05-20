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
        public async Task<CountryInfo> GetCountryInfo(string countryName)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(_baseUrl + countryName);
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
