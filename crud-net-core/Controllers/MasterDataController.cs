using crud_net_core.Model;
using Microsoft.AspNetCore.Mvc;

namespace crud_net_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterDataController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetCountries()
        {
            List<Countries> countries = new List<Countries>
            {
                new Countries { CountryId = 1, CountryName = "India" },
                new Countries { CountryId = 2, CountryName = "Australia" },
                new Countries { CountryId = 3, CountryName = "United Kingdom" }
            };

            if (!countries.Any())
            {
                NotFound("There are no countried in database");
            }

            return Ok(countries);
        }
 
        [HttpGet]
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
    }
}
