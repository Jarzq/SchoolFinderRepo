using SchoolFinder.Models;

namespace SchoolFinder.Services
{
    public interface IQueryService
    {
        IEnumerable<Subject> GetSubjects();
    }
}
