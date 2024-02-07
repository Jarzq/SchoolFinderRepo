using SchoolFinder.Controllers;
using SchoolFinder.DTOs;
using SchoolFinder.models;

namespace SchoolFinder.Services
{
    public interface ISchoolEntitiesService
    {
        IEnumerable<SchoolEntity> GetAllSchoolEntities();
        IEnumerable<SchoolEntitiesDTO> GetExactPreferredSchoolEntities(GetPrefferedSchoolEntitiesControllerRequest request);
        IEnumerable<SchoolEntitiesDTO> MapSchoolEntities(List<SchoolEntity> schoolEntities);
    }
}
