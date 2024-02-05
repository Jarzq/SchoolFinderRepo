using SchoolFinder.Controllers;
using SchoolFinder.models;

namespace SchoolFinder.Services
{
    public interface ISchoolEntitiesService
    {
        IEnumerable<SchoolEntity> GetAllSchoolEntities();
        IEnumerable<GetSchoolEntitiesControllerResponse> MapSchoolEntities(List<SchoolEntity> schoolEntities);
    }
}
