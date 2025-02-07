using crud_net_core.DataServices;
using crud_net_core.Model;
using Microsoft.AspNetCore.Mvc;

namespace crud_net_core.Controllers
{
    [Route("api/master-data")]
    [ApiController]
    public class MasterDataController : ControllerBase
    {
        MasterDataServices services;
        public MasterDataController()
        {
            services = new MasterDataServices();
        }

        [HttpGet]
        [Route("countries")]
        public ActionResult GetCountries()
        {
            List<Countries> countries = services.GetCountries();

            if (!countries.Any())
            {
                return NotFound("There are no countries in database");
            }

            return Ok(countries);
        }

        [HttpGet]
        [Route("states")]
        public ActionResult GetStates()
        {
            List<States> states = services.GetStates();

            if (!states.Any())
            {
                return NotFound("There are no states in database");
            }

            return Ok(states);
        }

        [HttpGet]
        [Route("cities")]
        public ActionResult GetCities()
        {
            List<Cities> cities = services.GetCities();

            if (!cities.Any())
            {
                return NotFound("There are no cities in database");
            }

            return Ok(cities);
        }
    }
}
