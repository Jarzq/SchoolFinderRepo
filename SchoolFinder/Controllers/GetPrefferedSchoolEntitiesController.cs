using Microsoft.AspNetCore.Mvc;
using SchoolFinder.Services;

namespace SchoolFinder.Controllers
{
    [ApiController]
    [Route("/PrefferedSchoolEntities")]
    public class GetPrefferedSchoolEntitiesController : ControllerBase
    {
        private readonly ISchoolEntitiesService _service;
        private readonly IConfiguration _configuration;

        public GetPrefferedSchoolEntitiesController(ISchoolEntitiesService service, IConfiguration configuration)
        {

            _service = service;
            _configuration = configuration;
        }

        [HttpPost(Name = "GetPrefferedSchoolEntities")]
        public async Task<GetPrefferedSchoolEntitiesControllerResponse> GetSchoolEntities([FromBody] GetPrefferedSchoolEntitiesControllerRequest request)
        {
            var exaxtPreferredSchoolEntities = _service.GetExactPreferredSchoolEntities(request);

            return  new GetPrefferedSchoolEntitiesControllerResponse() {ExactPrefferedSchools = exaxtPreferredSchoolEntities.ToList() };
        }
    }
}