using SchoolFinder.models;

namespace SchoolFinder.Services
{
    public interface ISchoolEntityService
    {
       Task AddSchoolEntityList(List<JednostkaSzkolna> jednostkaSzkolnaList);
    }
}
