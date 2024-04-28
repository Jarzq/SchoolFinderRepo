using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SchoolFinder.Services;

namespace SchoolFinder.Controllers
{
    [ApiController]
    [Route("/Specializations")]
    public class GetSpecializationsController : ControllerBase
    {
        private readonly ISchoolEntitiesService _service;
        private readonly IConfiguration _configuration;

        public GetSpecializationsController(ISchoolEntitiesService service, IConfiguration configuration)
        {
            _service = service;
            _configuration = configuration;
        }

        [HttpGet(Name = "GetSpecializations")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> GetSpecializations()
        {
            var specializations = _service.GetSpecializations().ToList();

            if (specializations == null)
                return NotFound();
            
            return Ok(specializations);
        }
    }
}