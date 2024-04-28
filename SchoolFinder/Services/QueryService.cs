using SchoolFinder.Data;
using SchoolFinder.Models;

namespace SchoolFinder.Services
{
    public class QueryService : IQueryService
    {
        private readonly SchoolfinderContext _dbContext;
        public QueryService(SchoolfinderContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Subject> GetSubjects()
        {
            return  _dbContext.Subjects;
        }
    }
}
