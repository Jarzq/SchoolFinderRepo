namespace SchoolFinder.DTOs
{
    public class SchoolEntitiesDTO
    {
        public int Id { get; set; }
        public string? District { get; set; }
        public string? SchoolName { get; set; }
        public string? EntitySymbol { get; set; }
        public string? EntityName { get; set; }
        public double? MinPoints { get; set; }
        public double? MaxPoints { get; set; }
        public int? SchoolTypeEnum { get; set; }
        public string? SchoolType { get; set; }
        public int? SpecializationId { get; set; }
        public string? Specialization { get; set; }
        public List<string>? ExtendedSubjects { get; set; } = new List<string>();
        public List<string>? Languages { get; set; } = new List<string>();
    }
}
