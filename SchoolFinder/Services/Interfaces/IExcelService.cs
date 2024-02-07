using SchoolFinder.models;

namespace SchoolFinder.Services
{
    public interface IExcelService
    {
        Task AddSchoolEntities(List<SchoolEntity> jednostkaSzkolnaList);
        Task AddSubjects();
        Task AssignSubjects();
        Task EnsuretablesEmpty();
        Task AddSpecializations();
        Task AssignSpecializations();
    }
}
