using Microsoft.EntityFrameworkCore;
using SchoolFinder.Data;
using SchoolFinder.models;
using System.Linq.Expressions;

namespace SchoolFinder.Services
{
    public class SchoolEntityService : ISchoolEntityService
    {
        private readonly SchoolfinderContext _dbContext;
        public SchoolEntityService(SchoolfinderContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddSchoolEntityList(List<JednostkaSzkolna> jednostkaSzkolnaList)
        {
            try
            {
                _dbContext.AddRange(jednostkaSzkolnaList);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("failed adding data to database", ex);
            }
        }
    }
}
