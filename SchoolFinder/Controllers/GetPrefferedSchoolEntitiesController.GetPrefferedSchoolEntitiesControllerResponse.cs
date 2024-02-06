using SchoolFinder.DTOs;

namespace SchoolFinder.Controllers
{
    public class GetPrefferedSchoolEntitiesControllerResponse
    {
        public List<SchoolEntitiesDTO>? ExactPrefferedSchools { get; set; }
        public List<SchoolEntitiesDTO>? NotExactPrefferedSchools { get; set; }
    }
}
