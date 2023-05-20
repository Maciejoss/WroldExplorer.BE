using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WorldExplorerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryInfoController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet("{countryName}")]
        public IEnumerable<string> Get([FromRoute] string countryName)
        {
            return new string[] { "value1", "value2" };
        }

    }
}
