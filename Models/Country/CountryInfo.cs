namespace WorldExplorerApi.Models.Country
{
    public class Name
    {
        public string Common { get; set; }
        public string Official { get; set; }
        public NativeName NativeName { get; set; }
    }

    public class NativeName
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
    }

    public class CountryInfo
    {
        public Name Name { get; set; }
        public List<string> Tld { get; set; }
        public string Cca2 { get; set; }
        public string Ccn3 { get; set; }
        public string Cca3 { get; set; }
        public string Cioc { get; set; }
        public bool Independent { get; set; }
        public string Status { get; set; }
        public bool UnMember { get; set; }
        public Currencies Currencies { get; set; }
        public Idd Idd { get; set; }
        public List<string> Capital { get; set; }
        public List<string> AltSpellings { get; set; }
        public string Region { get; set; }
        public string Subregion { get; set; }
        public Dictionary<string, string> Languages { get; set; }
        public Translations Translations { get; set; }
        public List<double> Latlng { get; set; }
        public bool Landlocked { get; set; }
        public List<string> Borders { get; set; }
        public double Area { get; set; }
        public Demonyms Demonyms { get; set; }
        public string Flag { get; set; }
        public Dictionary<string, string> Maps { get; set; }
        public int Population { get; set; }
        public Dictionary<string, double> Gini { get; set; }
        public string Fifa { get; set; }
        public Car Car { get; set; }
        public List<string> Timezones { get; set; }
        public List<string> Continents { get; set; }
        public Flags Flags { get; set; }
        public CoatOfArms CoatOfArms { get; set; }
        public string StartOfWeek { get; set; }
        public CapitalInfo CapitalInfo { get; set; }
        public PostalCode PostalCode { get; set; }
    }
}
