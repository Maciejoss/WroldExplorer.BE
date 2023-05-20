using GraphQL.Client.Abstractions;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using WorldExplorerApi.Models.Continent;
using WorldExplorerApi.Models.Country;

namespace WorldExplorerApi.Controllers.ApiHelpers
{
    public class GraphQLApiService
    {
        GraphQLHttpClient _graphQLClient;
        public GraphQLApiService(IConfiguration configuration)
        {
            GraphQLHttpClientOptions graphQLHttpClientOptions = new GraphQLHttpClientOptions
            {
                EndPoint = new Uri(configuration.GetSection("DataApisUrls").GetValue<string>("ContinentsAndCountriesUrl"))
            };

            _graphQLClient = new GraphQLHttpClient(graphQLHttpClientOptions,new NewtonsoftJsonSerializer());
        }

        public async Task<IEnumerable<ContinentInfo>> GetAllContinentsCodes()
        {
            var continentsRequest = new GraphQLRequest
            {
                Query = _CreateContinentsCodesAndNamesQuery()
            };

            var graphQLResponse = await _graphQLClient.SendQueryAsync<GraphQLContinentsResponse>(continentsRequest);

            return graphQLResponse.Data.Continents;
        }

        public async Task<IEnumerable<Country>> GetCountriesOnContinent(string continentCode)
        {
            var countriesRequest = new GraphQLRequest
            {
                Query = _CreateCountriesInContinentInfoQuery(continentCode)
            };

            var graphQLResponse = await _graphQLClient.SendQueryAsync<GraphQLCountriesResponse>(countriesRequest);

            return graphQLResponse.Data.Continent.Countries;

        }

        string _CreateContinentsCodesAndNamesQuery()
        {
            return @"
                    query Query {
                        continents {
                            code,
                            name
                        }
                    }";
        }
        string _CreateCountriesInContinentInfoQuery(string continentCode)
        {
            return @"
                    query Query{
                        continent(code: """ + continentCode + @""") {
                        countries {
                            name
                        }
                     }
                    }";
        }
    }
}
