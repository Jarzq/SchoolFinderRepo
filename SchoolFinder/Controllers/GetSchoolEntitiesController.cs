using Microsoft.AspNetCore.Mvc;
using SchoolFinder.Helpers;
using SchoolFinder.Services;
using System.Net;

namespace SchoolFinder.Controllers
{
    [ApiController]
    [Route("/SchoolEntities")]
    public class GetSchoolEntitiesController : ControllerBase
    {
        private readonly ISchoolEntitiesService _service;
        private readonly IConfiguration _configuration;

        public GetSchoolEntitiesController(ISchoolEntitiesService service, IConfiguration configuration)
        {

            _service = service;
            _configuration = configuration;
        }

        [HttpGet(Name = "GetSchoolEntities")]
        public async Task<List<GetSchoolEntitiesControllerResponse>> GetSchoolEntities()
        {
           var schoolEntities = _service.GetAllSchoolEntities().ToList();

           var mappedSchoolEntites = _service.MapSchoolEntities(schoolEntities).ToList();

            return mappedSchoolEntites;
        }
    }
}