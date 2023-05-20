namespace WorldExplorerApi.Models.Country
{
    public class GraphQLCountriesResponse
    {
        public Continent Continent { get; set; }
    }

    public class Continent
    {
        public Country[] Countries { get; set; }
    }
}
