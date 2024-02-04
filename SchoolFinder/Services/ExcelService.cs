using Microsoft.EntityFrameworkCore;
using SchoolFinder.Data;
using SchoolFinder.Enums;
using SchoolFinder.models;
using SchoolFinder.Models;
using System.Linq;

namespace SchoolFinder.Services
{
    public class ExcelService : IExcelService
    {
        private readonly SchoolfinderContext _dbContext;
        public ExcelService(SchoolfinderContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddSchoolEntities(List<SchoolEntity> schoolEntities)
        {
            try
            {
                var schoolsWithTypes = AssignTypes(schoolEntities);

                _dbContext.UpdateRange(schoolsWithTypes);
                await _dbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        private List<SchoolEntity> AssignTypes(List<SchoolEntity> schoolEntities)
        {
            foreach (SchoolEntity school in schoolEntities)
            {
                if (school.NazwaSzkoly.Contains(SchoolType.Liceum.ToString()))
                {
                    school.SchoolType = (int)SchoolType.Liceum;
                }
                else if (school.NazwaSzkoly.Contains(SchoolType.Technikum.ToString()))
                {
                    school.SchoolType = (int)SchoolType.Technikum;
                }
                else if (school.NazwaSzkoly.Contains(SchoolType.Branżowa.ToString()))
                {
                    school.SchoolType = (int)SchoolType.Branżowa;
                }
            }
            return schoolEntities;
        }

        public async Task AssignSpecializations()
        {
            var allspecializations = _dbContext.Specializations.ToList();
            var schoolEntities = _dbContext.SchoolEntities.ToList();
            foreach (SchoolEntity school in schoolEntities)
            {
                foreach(var specialization in allspecializations)
                {
                    if (school.NazwaOddzialu.Contains(specialization.Name))
                    {
                        school.Specialization = specialization;
                    }
                }
            }
            _dbContext.UpdateRange(schoolEntities);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AssignSubjects()
        {
            var allSubjects = _dbContext.Subjects.ToList();
            var allEntities = _dbContext.SchoolEntities.ToList();
            List<SchoolEntitySubject> schoolEntitySubjects = new List<SchoolEntitySubject>();
            List<SchoolEntityLanguageSubject> schoolEntityLanguageSubjects = new List<SchoolEntityLanguageSubject>();

            foreach (var subject in allSubjects)
            {
                foreach (var entity in allEntities)
                {
                    var chunks = entity.NazwaOddzialu.Split(" ");
                    if (chunks[1].Contains(subject.Name))
                    {
                        var entitySubject = new SchoolEntitySubject() { SchoolEntity = entity, Subject = subject };
                        schoolEntitySubjects.Add(entitySubject);
                    }
                    for (int i = 0; i < chunks.Length; i++)
                    {
                        if (chunks[i].Contains("(") && chunks[i].Contains(subject.Name))
                        {
                            var entityLanguageSubject = new SchoolEntityLanguageSubject() { SchoolEntity = entity, LanguageSubject = subject };
                            schoolEntityLanguageSubjects.Add(entityLanguageSubject);
                        }
                    }
                }
            }


            _dbContext.AddRange(schoolEntitySubjects);
            _dbContext.AddRange(schoolEntityLanguageSubjects);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddSubjects()
        {
            var allLiceum = _dbContext.SchoolEntities.Where(e => e.SchoolType == 1).ToList();
            var subjectNames = new HashSet<string>();
            var subjectList = new List<Subject>();

            foreach (var schoolEntity in allLiceum)
                subjectNames.UnionWith(ExtractSubjectNames(schoolEntity.NazwaOddzialu));

            foreach (var subjectName in subjectNames)
            {
                var subject = new Subject() { Name = subjectName };
                subjectList.Add(subject);
            }
            _dbContext.AddRange(subjectList);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddSpecializations()
        {
            var allEntities = _dbContext.SchoolEntities.Where(e => e.SchoolType != 1).ToList();
            var specializationNames = new HashSet<string>();
            var specializationList = new List<Specialization>();

            foreach (var schoolEntity in allEntities)
                specializationNames.Add(ExtractSpecializationNames(schoolEntity.NazwaOddzialu));

            foreach (var specializationName in specializationNames)
            {
                var specialization = new Specialization() { Name = specializationName };
                specializationList.Add(specialization);
            }
            _dbContext.AddRange(specializationList);
            await _dbContext.SaveChangesAsync();
        }

        private string ExtractSpecializationNames(string nazwaOddzialu)
        {
            string[] chunks = nazwaOddzialu.Split(']');
            var correctChunk = chunks[1].Split("(");
            return correctChunk[0];
        }

        private List<string> ExtractSubjectNames(string inputString)
        {
            string[] parts = inputString.Split(' ');
            string[] singleNames = new string[0];
            List<string> subjectNames = new List<string>();

            for (int i = 1; i < parts.Length; i++)
            {
                if (parts[i].Contains('-'))
                {
                    singleNames = parts[i].Split(new char[] { '-', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var name in singleNames)
                    {
                        string cleanedName = name.Replace("*", "").Replace("(", "").Replace(")", "");
                        subjectNames.Add(cleanedName);
                    }
                }
            }

            return subjectNames;
        }

        public async Task EnsuretablesEmpty()
        {
            bool isSchoolEntitiesEmpty = !await _dbContext.SchoolEntities.AnyAsync();
            bool isSchoolEntityLanguageSubjectsEmpty = !await _dbContext.SchoolEntityLanguageSubjects.AnyAsync();
            bool isSchoolEntitySubjectsEmpty = !await _dbContext.SchoolEntitySubjects.AnyAsync();
            bool isSubjectsEmpty = !await _dbContext.Subjects.AnyAsync();
            bool isSpecializationsEmpty = !await _dbContext.Specializations.AnyAsync();

            if (!isSchoolEntitiesEmpty)
            {
                _dbContext.SchoolEntities.RemoveRange(await _dbContext.SchoolEntities.ToListAsync());
            }

            if (!isSchoolEntityLanguageSubjectsEmpty)
            {
                _dbContext.Subjects.RemoveRange(await _dbContext.Subjects.ToListAsync());
            }

            if (!isSchoolEntitySubjectsEmpty)
            {
                _dbContext.SchoolEntitySubjects.RemoveRange(await _dbContext.SchoolEntitySubjects.ToListAsync());
            }

            if (!isSubjectsEmpty)
            {
                _dbContext.Subjects.RemoveRange(await _dbContext.Subjects.ToListAsync());
            }

            if (!isSpecializationsEmpty)
            {
                _dbContext.Specializations.RemoveRange(await _dbContext.Specializations.ToListAsync());
            }

            await _dbContext.SaveChangesAsync();
        }
    }
}
