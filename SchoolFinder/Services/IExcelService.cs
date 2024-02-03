using SchoolFinder.models;

namespace SchoolFinder.Services
{
    public interface IExcelService
    {
        Task AddSchoolEntityList(List<SchoolEntity> jednostkaSzkolnaList);
        Task AddSchoolTypes(List<SchoolEntity> jednostkaSzkolnaList);
        List<string> AddSubjects(List<SchoolEntity> schoolEntities);
    }
}
