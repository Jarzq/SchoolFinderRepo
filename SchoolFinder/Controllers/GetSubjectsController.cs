using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SchoolFinder.Services;

namespace SchoolFinder.Controllers
{
    [ApiController]
    [Route("/Subjects")]
    public class GetSubjectsController : ControllerBase
    {
        private readonly ISchoolEntitiesService _service;
        private readonly IConfiguration _configuration;

        public GetSubjectsController(ISchoolEntitiesService service, IConfiguration configuration)
        {
            _service = service;
            _configuration = configuration;
        }

        [HttpGet(Name = "GetSubjects")]
        [EnableCors("AllowOrigin")] // Apply CORS policy
        public async Task<IActionResult> GetSubjects()
        {
            var subjects = _service.GetSubjects();

            if (subjects == null)
            {
                return NotFound();
            }
            return Ok(subjects);
        }
    }
}