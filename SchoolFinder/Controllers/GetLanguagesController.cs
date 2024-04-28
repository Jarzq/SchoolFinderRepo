using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SchoolFinder.Services;

namespace SchoolFinder.Controllers
{
    [ApiController]
    [Route("/Languages")]
    public class GetLanguagesController : ControllerBase
    {
        private readonly ISchoolEntitiesService _service;
        private readonly IConfiguration _configuration;

        public GetLanguagesController(ISchoolEntitiesService service, IConfiguration configuration)
        {
            _service = service;
            _configuration = configuration;
        }

        [HttpGet(Name = "GetLanguages")]
        [EnableCors("AllowOrigin")] // Apply CORS policy
        public async Task<IActionResult> GetLanguages()
        {
            var languages = _service.GetLanguages().ToList();

            if (languages == null)
            {
                return NotFound();
            }
            return Ok(languages);
        }
    }
}