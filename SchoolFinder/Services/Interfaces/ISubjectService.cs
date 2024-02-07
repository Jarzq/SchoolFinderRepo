using SchoolFinder.Models;

namespace SchoolFinder.Services
{
    public interface ISubjectService
    {
        IEnumerable<Subject> GetSubjects();
    }
}
