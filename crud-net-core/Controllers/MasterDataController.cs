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
    }
}
