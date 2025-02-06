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
            List<States> states = new List<States>
            {
                new States { StateId = 1, StateName = "Andhra Pradesh" },
                new States { StateId = 2, StateName = "Arunachal Pradesh" },
                new States { StateId = 3, StateName = "Assam" },
                new States { StateId = 4, StateName = "Karnataka" },
                new States { StateId = 5, StateName = "Kerala" },
                new States { StateId = 6, StateName = "Maharashtra" },
            };

            if (!states.Any())
            {
                NotFound("There are no states in database");
            }

            return Ok(states);
        }

        [HttpGet]
        [Route("cities")]
        public ActionResult GetCities()
        {
            List<Cities> cities = new List<Cities>
            {
                new Cities { CityId = 1, CityName = "Mumbai" },
                new Cities { CityId = 2, CityName = "Pune" },
                new Cities { CityId = 3, CityName = "Nagpur" },
                new Cities { CityId = 4, CityName = "Solapur" },
                new Cities { CityId = 5, CityName = "Kolhapur" },
                new Cities { CityId = 6, CityName = "Nanded" },
            };

            if (!cities.Any())
            {
                NotFound("There are no cities in database");
            }

            return Ok(cities);
        }
    }
}
