using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SchoolFinder.Services;

namespace SchoolFinder.Controllers
{
    [ApiController]
    [Route("/Districts")]
    public class GetDistrictsController : ControllerBase
    {
        private readonly ISchoolEntitiesService _service;
        private readonly IConfiguration _configuration;

        public GetDistrictsController(ISchoolEntitiesService service, IConfiguration configuration)
        {
            _service = service;
            _configuration = configuration;
        }

        [HttpGet(Name = "GetDistricts")]
        [EnableCors("AllowOrigin")] // Apply CORS policy
        public async Task<IActionResult> GetDistricts()
        {
            var districts = _service.GetDistricts().ToList();

            if (districts == null)
            {
                return NotFound();
            }
            return Ok(districts);
        }
    }
}