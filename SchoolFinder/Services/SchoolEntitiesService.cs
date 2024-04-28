using Microsoft.EntityFrameworkCore;
using SchoolFinder.Controllers;
using SchoolFinder.Data;
using SchoolFinder.DTOs;
using SchoolFinder.Enums;
using SchoolFinder.models;
using SchoolFinder.Models;
using System.ComponentModel.DataAnnotations;

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
                    .ThenInclude(s => s.Subject)
                .Include(s => s.SchoolEntityLanguageSubjects)
                    .ThenInclude(s => s.LanguageSubject);


        }

        public IEnumerable<SchoolEntitiesDTO> MapSchoolEntities(List<SchoolEntity> schoolEntities)
        {
            var subjects = _dbContext.Subjects.ToList();
            var mappedSchoolEntityList = new List<SchoolEntitiesDTO>();

            foreach (var schoolEntity in schoolEntities)
            {
                var mappedSchoolEntity = new SchoolEntitiesDTO()
                {
                    Id = schoolEntity.Id,
                    District = schoolEntity.Dzielnica,
                    MaxPoints = schoolEntity.MaksymalnePunkty,
                    MinPoints = schoolEntity.MinimalnePunkty,
                    EntityName = schoolEntity.NazwaOddzialu,
                    SchoolName = schoolEntity.NazwaSzkoly,
                    SchoolTypeEnum = schoolEntity.SchoolType,
                    SpecializationId = schoolEntity.SpecializationId,
                    ExtendedSubjects = schoolEntity.SchoolEntitySubjects
                        .Select(ses => subjects.FirstOrDefault(s => s.Id == ses.SubjectId)?.FullName)
                        .ToList(),
                    Languages = schoolEntity.SchoolEntityLanguageSubjects
                        .Select(schoolEntityLanguage => subjects.FirstOrDefault(s => s.Id == schoolEntityLanguage.LanguageSubjectId)?.FullName)
                        .ToList(),
                    Specialization = schoolEntity.Specialization?.Name,
                    SchoolType = Enum.GetName(typeof(SchoolType), schoolEntity.SchoolType),
                };

                mappedSchoolEntityList.Add(mappedSchoolEntity);
            }
            return mappedSchoolEntityList;
        }

        public IEnumerable<SchoolEntitiesDTO> GetExactPreferredSchoolEntities(GetPrefferedSchoolEntitiesControllerRequest request)
        {
            var allSchoolEntities = GetAllSchoolEntities();
            List<SchoolEntity> preferredEntities = new List<SchoolEntity>();

            foreach (var entity in allSchoolEntities)
            {
                var schoolTypeEnumValue = (SchoolType)entity.SchoolType;

                var isDzielnicaOk = CheckDzielnica(request.PrefferedDzielnica, entity.Dzielnica);
                var isSpecializacionNameOk = schoolTypeEnumValue == SchoolType.Liceum || CheckSpecializationName(request.PrefferedSpecialization, entity.Specialization?.Name);
                var isSchoolTypeOk = CheckSchoolType(request.PrefferedSchoolType, entity.SchoolType);
                var isPointsOk = CheckPoints(request.AcheivedPunkty, request.rangeDecrease, request.RangeIncrease, entity.MinimalnePunkty);
                var isSubjectListOk = schoolTypeEnumValue != SchoolType.Liceum || CheckSubjects(request.NumberMatchingSubjects, request.PrefferedExtendedSubjects, entity.SchoolEntitySubjects);
                var isLanguageListOk = CheckLanguages(request.NumberMatchingLanguages, request.PrefferedLanguages, entity.SchoolEntityLanguageSubjects);

                if (isDzielnicaOk && isSpecializacionNameOk && isSchoolTypeOk && isPointsOk && isSubjectListOk && isLanguageListOk)
                {
                    preferredEntities.Add(entity);
                }
            }

            return MapSchoolEntities(preferredEntities);
        }

        private bool CheckDzielnica(string? prefferedDzielnica, string entityDzielnica)
        {
            if (prefferedDzielnica == entityDzielnica || prefferedDzielnica == null)
                return true;
            return false;
        }
        private bool CheckSpecializationName(string? prefferedSpecialization, string entitySpecialization)
        {
            if (prefferedSpecialization == entitySpecialization || prefferedSpecialization == null)
                return true;
            return false;
        }
        private bool CheckSchoolType(string prefferedSchoolType, int entitySchoolType)
        {

            if (prefferedSchoolType == Enum.GetName(typeof(SchoolType), entitySchoolType))
                return true;
            return false;
        }
        private bool CheckPoints(double? acheivedPunkty, double? rangeDecrease, double? rangeIncrease, double minimalnePunkty)
        {
            if ((minimalnePunkty - acheivedPunkty <= rangeDecrease) && (acheivedPunkty - minimalnePunkty <= rangeIncrease))
                return true;
            return false;
        }
        private bool CheckLanguages(int numberMatchingLanguages, List<string>? prefferedLanguages, List<SchoolEntityLanguageSubject>? schoolEntityLanguageSubjects)
        {
            int counter = 0;
            foreach (SchoolEntityLanguageSubject schoolEntityLanguageSubject in schoolEntityLanguageSubjects)
            {
                if (prefferedLanguages == null)
                    return true;
                if (prefferedLanguages.Contains(schoolEntityLanguageSubject.LanguageSubject.Name))
                {
                    counter++;
                }
                if (counter >= numberMatchingLanguages)
                    return true;
            }
            return false;
        }

        private bool CheckSubjects(int numberMatchingSubjects, List<string>? prefferedExtendedSubjects, List<SchoolEntitySubject>? schoolEntitySubjects)
        {
            int counter = 0;
            foreach (SchoolEntitySubject schoolEntitySubject in schoolEntitySubjects)
            {
                if (prefferedExtendedSubjects == null)
                    return true;
                if (prefferedExtendedSubjects.Contains(schoolEntitySubject.Subject.Name))
                {
                    counter++;
                }
                if (counter >= numberMatchingSubjects)
                    return true;
            }
            return false;
        }

        public IEnumerable<string> GetDistricts()
        {
            return _dbContext.SchoolEntities.Select(s => s.Dzielnica).Distinct();
        }

        public IEnumerable<string> GetLanguages()
        {
            var languageIds = _dbContext.SchoolEntityLanguageSubjects.Select(s => s.LanguageSubjectId).Distinct();
            var languagesList = _dbContext.Subjects
                .Where(subject => languageIds.Contains(subject.Id))
                .Select(subject => subject.FullName)
                .ToList();

            return languagesList;
        }

        public IEnumerable<string> GetSpecializations()
        {
            return _dbContext.SchoolEntities.Select(s => s.Specialization.Name).Where(name => name != null).Distinct();
        }
    }
}
