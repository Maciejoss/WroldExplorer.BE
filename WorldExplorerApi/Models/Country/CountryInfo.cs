using Newtonsoft.Json.Linq;

namespace WorldExplorerApi.Models.Country
{
    public class Name
    {
        public string Common { get; set; }
        public string Official { get; set; }
/*        public NativeName NativeName { get; set; }*/
    }

 /*   public class NativeName
    {
        public OfficialName Pol { get; set; }
    }

    public class OfficialName
    {
        public string Official { get; set; }
        public string Common { get; set; }
    }

    public class Currencies
    {
        public Currency PLN { get; set; }
    }

    public class Currency
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
    }

    public class Idd
    {
        public string Root { get; set; }
        public List<string> Suffixes { get; set; }
    }

    public class Translations
    {
        public Translation Ara { get; set; }
        public Translation Bre { get; set; }
        public Translation Ces { get; set; }
        // Add other translation properties as needed
    }

    public class Translation
    {
        public string Official { get; set; }
        public string Common { get; set; }
    }

    public class Demonyms
    {
        public Demonym Eng { get; set; }
        public Demonym Fra { get; set; }
        // Add other demonym properties as needed
    }

    public class Demonym
    {
        public string F { get; set; }
        public string M { get; set; }
    }

    public class Flags
    {
        public string Png { get; set; }
        public string Svg { get; set; }
        public string Alt { get; set; }
    }

    public class CoatOfArms
    {
        public string Png { get; set; }
        public string Svg { get; set; }
    }

    public class CapitalInfo
    {
        public List<double> Latlng { get; set; }
    }

    public class PostalCode
    {
        public string Format { get; set; }
        public string Regex { get; set; }
    }*/

    public class CountryInfo
    {
        public Name Name { get; set; }

        public CountryInfo(JObject jObject) {
            Name = new Name();
            Name.Common = jObject["name"]?["common"]?.ToString();
            Name.Official = jObject["name"]?["official"]?.ToString();
        }
    }
}
