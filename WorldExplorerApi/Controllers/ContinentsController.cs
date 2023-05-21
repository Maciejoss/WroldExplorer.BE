using Microsoft.AspNetCore.Mvc;
using GraphQL.Client.Http;
using WorldExplorerApi.Models.Continent;
using WorldExplorerApi.Models.Country;
using WorldExplorerApi.Controllers.ApiHelpers;
using System;
using System.Diagnostics.Metrics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WorldExplorerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContinentsController : ControllerBase
    {
        GraphQLApiService _graphQLApiService;
        CountryInfoService _countryInfoService;

        public ContinentsController(CountryInfoService countryInfoService,GraphQLApiService graphQLApiService)
        {
            _graphQLApiService = graphQLApiService;
            _countryInfoService = countryInfoService;
        }

        // GET: api/<ContriesController>
        [HttpGet]
        public async Task<IEnumerable<ContinentInfo>> Get()
        {

            var continentsCodes = await _graphQLApiService.GetAllContinentsCodes();

            return continentsCodes;
        }

        // GET api/<ContriesController>/5
        [HttpGet("{continentCode}/countries/{count}")]
        public async Task<IEnumerable<CountryInfo>> Get([FromRoute] string continentCode, [FromRoute] int count)
        {

            var graphQLResponse = await _graphQLApiService.GetCountriesOnContinent(continentCode);

            Random rnd = new Random();

            var countryInfos = await _countryInfoService.SelectRandomCountriesInfos(graphQLResponse.ToList(), count);

            return countryInfos;

        }


        }
}
