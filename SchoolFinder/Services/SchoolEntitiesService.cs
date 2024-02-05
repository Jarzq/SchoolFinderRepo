using Microsoft.EntityFrameworkCore;
using SchoolFinder.Controllers;
using SchoolFinder.Data;
using SchoolFinder.Enums;
using SchoolFinder.models;

namespace SchoolFinder.Services
{
    public class SchoolEntitiesService : ISchoolEntitiesService
    {
        private readonly SchoolfinderContext _dbContext;
        public SchoolEntitiesService(SchoolfinderContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<SchoolEntity> GetAllSchoolEntities()
        {
            return _dbContext.SchoolEntities.Include(schoolEntity => schoolEntity.Specialization)
                .Include(s => s.SchoolEntitySubjects)
                .Include(s => s.SchoolEntityLanguageSubjects);
        }

        public IEnumerable<GetSchoolEntitiesControllerResponse> MapSchoolEntities(List<SchoolEntity> schoolEntities)
        {
            var subjects = _dbContext.Subjects.ToList();
            var mappedSchoolEntityList = new List<GetSchoolEntitiesControllerResponse>();

            foreach (var schoolEntity in schoolEntities)
            {
                var mappedSchoolEntity = new GetSchoolEntitiesControllerResponse()
                {
                    Id = schoolEntity.Id,
                    Dzielnica = schoolEntity.Dzielnica,
                    MaksymalnePunkty = schoolEntity.MaksymalnePunkty,
                    MinimalnePunkty = schoolEntity.MinimalnePunkty,
                    NazwaOddzialu = schoolEntity.NazwaOddzialu,
                    NazwaSzkoly = schoolEntity.NazwaSzkoly,
                    SchoolTypeEnum = schoolEntity.SchoolType,
                    SpecializationId = schoolEntity.SpecializationId,
                    ExtendedSubjects = schoolEntity.SchoolEntitySubjects
                        .Select(ses => subjects.FirstOrDefault(s => s.Id == ses.SubjectId)?.Name)
                        .ToList(),
                    Languages = schoolEntity.SchoolEntityLanguageSubjects
                        .Select(schoolEntityLanguage => subjects.FirstOrDefault(s => s.Id == schoolEntityLanguage.LanguageSubjectId)?.Name)
                        .ToList(),
                    Specialization = schoolEntity.Specialization?.Name,
                    SchoolType = Enum.GetName(typeof(SchoolType), schoolEntity.SchoolType),
                };

                mappedSchoolEntityList.Add(mappedSchoolEntity);
            }
            return mappedSchoolEntityList;
        }
    }
}
