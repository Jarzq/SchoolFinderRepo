using SchoolFinder.Data;
using SchoolFinder.Enums;
using SchoolFinder.models;
using SchoolFinder.Models;

namespace SchoolFinder.Services
{
    public class ExcelService : IExcelService
    {
        private readonly SchoolfinderContext _dbContext;
        public ExcelService(SchoolfinderContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddSchoolEntityList(List<SchoolEntity> jednostkaSzkolnaList)
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

        public async Task AddSchoolTypes(List<SchoolEntity> schoolEntities)
        {
            var schoolsWithTypes = ExtractTypes(schoolEntities);
            _dbContext.UpdateRange(schoolsWithTypes);
            await _dbContext.SaveChangesAsync();
        }

        private List<SchoolEntity> ExtractTypes(List<SchoolEntity> schoolEntities)
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
    }
}
