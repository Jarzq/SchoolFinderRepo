using SchoolFinder.Data;
using SchoolFinder.Models;

namespace SchoolFinder.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly SchoolfinderContext _dbContext;
        public SubjectService(SchoolfinderContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Subject> GetSubjects()
        {
            return  _dbContext.Subjects;
        }
    }
}
