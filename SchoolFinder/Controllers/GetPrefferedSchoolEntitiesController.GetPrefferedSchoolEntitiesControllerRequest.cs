namespace SchoolFinder.Controllers
{
    public class GetPrefferedSchoolEntitiesControllerRequest
    {
        public List<string>? PrefferedDzielnica { get; set; }
        public double? AcheivedPunkty { get; set; }
        public double? RangeIncrease { get; set; }
        public double? rangeDecrease { get; set; }
        public string PrefferedSchoolType { get; set; }
        public string? PrefferedSpecialization { get; set; }
        public List<string>? PrefferedExtendedSubjects { get; set; } = new List<string>();
        public int NumberMatchingSubjects { get; set; } = 1;
        public List<string>? PrefferedLanguages { get; set; } = new List<string>();
        public int NumberMatchingLanguages { get; set; } = 1;
    }
}
