namespace SchoolFinder.Controllers
{
    public class GetSchoolEntitiesControllerResponse
    {
        public int Id { get; set; }
        public string? Dzielnica { get; set; }
        public string? NazwaSzkoly { get; set; }
        public string? SymbolOddzialu { get; set; }
        public string? NazwaOddzialu { get; set; }
        public double? MinimalnePunkty { get; set; }
        public double? MaksymalnePunkty { get; set; }
        public int? SchoolTypeEnum { get; set; }
        public string? SchoolType { get; set; }
        public int? SpecializationId { get; set; }
        public string? Specialization { get; set; }
        public List<string>? ExtendedSubjects { get; set;} = new List<string>();
        public List<string>? Languages { get; set;} = new List<string>();
    }
}
