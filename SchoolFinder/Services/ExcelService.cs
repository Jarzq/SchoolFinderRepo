using Microsoft.OpenApi.Extensions;
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
            foreach(SchoolEntity school in schoolEntities)
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

        public List<string> AddSubjects(List<SchoolEntity> schoolEntities)
        {
            List<string> subjectNames = new List<string>();
            foreach (var schoolEntity in schoolEntities)
            {
                subjectNames.AddRange(ExtractSubjectNames(schoolEntity.NazwaOddzialu));
            }
            subjectNames = subjectNames.Distinct().ToList();
            return subjectNames;
        }

        private List<string> ExtractSubjectNames(string inputString)
        {
            string[] parts = inputString.Split(' ');
            string[] singleNames = new string[0];
            List<string> subjectNames = new List<string>();

            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i].Contains('-'))
                {
                    singleNames = parts[i].Split('-');
                    subjectNames = new List<string>(singleNames);
                    break;
                }
            }

            return subjectNames;
        }
    }
}
