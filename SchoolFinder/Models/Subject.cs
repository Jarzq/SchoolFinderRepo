using System.ComponentModel.DataAnnotations;

namespace SchoolFinder.Models
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }

        private string? _name;
        public string? Name
        {
            get => _name;
            set
            {
                _name = value;
                FullName = GetFullName();
            }
        }

        public string? FullName { get; private set; }

        public List<SchoolEntitySubject> SchoolEntitySubjects { get; set; }
        public List<SchoolEntityLanguageSubject> SchoolEntityLanguageSubjects { get; set; }
        private string GetFullName()
        {
            Dictionary<string, string> subjectShortcuts = new Dictionary<string, string>
            {
                { "pol", "Język Polski" },
                { "geogr", "Geografia" },
                { "hist", "Historia" },
                { "ang", "Język angielski" },
                { "hisz", "Język hiszpański" },
                { "niem", "Język niemiecki" },
                { "mat", "Matematyka" },
                { "biol", "Biologia" },
                { "chem", "Chemia" },
                { "hiszp", "Język hiszpański" },
                { "fiz", "Fizyka" },
                { "wos", "Wiedza o społeczeństwie" },
                { "fra", "Język francuski" },
                { "franc", "Język francuski" },
                { "inf", "Informatyka" },
                { "obcy", "Język obcy" },
                { "wlo", "Język włoski" },
                { "filoz", "Filozofia" },
                { "ros", "Język rosyjski" },
                { "h.szt.", "Historia sztuki" },
                { "biz", "Biznes" },
                { "szwe", "Język szwedzki" },
                { "por", "Język portugalski" },
                { "łac", "Język łaciński" },
                { "antyk", "Historia starożytna" },
                { "wło", "Język włoski" },
                { "h.muz.", "Historia muzyki" }
            };

            if (!string.IsNullOrEmpty(Name) && subjectShortcuts.ContainsKey(Name.ToLower()))
            {
                return subjectShortcuts[Name.ToLower()];
            }
            else
            {
                return "Unknown";
            }
        }

        //constructors
        public Subject()
        {
            FullName = GetFullName();
        }
    }
}