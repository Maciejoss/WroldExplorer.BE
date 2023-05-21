using Newtonsoft.Json.Linq;

namespace WorldExplorerApi.Models.Country
{
    public class Currency
    {

        public string? Name { get; set; }
        public string? Symbol { get; set; }
    }

    public class CountryInfo
    {
        public String? OfficialName { get; set; }
        public String? Capital { get; set; }
        public int? Population { get; set; }
        public Currency[]? Currencies { get; set; }
        public String? Subregion { get; set; }
        public String[]? Languages { get; set; }

        public CountryInfo(JObject jObject)
        {
            OfficialName = jObject["name"]?["official"]?.ToString();
            Capital = jObject["capital"]?.FirstOrDefault()?.ToString();
            Population = jObject["population"]?.ToObject<int?>();

            var currencies = jObject["currencies"];


            if (currencies != null)
            {
                var currencyList = new List<Currency>();
                foreach (JProperty currency in currencies.Children())
                {
                    var currencyObj = new Currency
                    {
                        Name = currency.Value?["name"]?.ToString(),
                        Symbol = currency.Value?["symbol"]?.ToString()
                    };
                    currencyList.Add(currencyObj);
                }
                Currencies = currencyList.ToArray();
            }

            Subregion = jObject["subregion"]?.ToString();

            var languages = jObject["languages"];
            if (languages != null)
            {
                var languageList = new List<string>();
                foreach (JProperty language in languages.Children())
                {
                    languageList.Add(language.Value.ToString());
                }
                Languages = languageList.ToArray();
            }
        }
    }
}
