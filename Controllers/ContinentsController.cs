using Microsoft.AspNetCore.Mvc;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Newtonsoft.Json;
using WorldExplorerApi.Models.Continent;
using WorldExplorerApi.Models.Country;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WorldExplorerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContinentsController : ControllerBase
    {
        GraphQLHttpClientOptions graphQLHttpClientOptions;
        GraphQLHttpClient graphQLClient;

        public ContinentsController() {
            graphQLHttpClientOptions = new GraphQLHttpClientOptions
            {
                EndPoint = new Uri("https://countries.trevorblades.com/graphql")
            };
            graphQLClient = new GraphQLHttpClient(graphQLHttpClientOptions, new NewtonsoftJsonSerializer());
        }

        // GET: api/<ContriesController>
        [HttpGet]
        public async Task<IEnumerable<ContinentInfo>> Get()
        {

            var continentsRequest = new GraphQLRequest
            {
                Query = @"
                    query Query {
                        continents {
                            code,
                            name
                        }
                    }"
            };

            var graphQLResponse = await graphQLClient.SendQueryAsync<GraphQLContinentsResponse>(continentsRequest);

            return graphQLResponse.Data.Continents;
        }

        // GET api/<ContriesController>/5
        [HttpGet("{continentCode}/countries/{count}")]
        public async Task<IEnumerable<Country>> Get([FromRoute] string continentCode, [FromRoute] int count)
        {
            var countriesRequest = new GraphQLRequest
            {
                Query = @"
                    query Query{
                        continent(code: """+continentCode+@""") {
                        countries {
                            name
                        }
                     }
                    }"
            };

            var graphQLResponse = await graphQLClient.SendQueryAsync<GraphQLCountriesResponse>(countriesRequest);

            Random rnd = new Random();

            return graphQLResponse.Data.Continent.Countries.OrderBy(x=>rnd.Next()).Take(count);

        }

    }
}
