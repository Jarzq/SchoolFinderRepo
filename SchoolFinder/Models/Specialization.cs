using SchoolFinder.models;
using System.ComponentModel.DataAnnotations;

namespace SchoolFinder.Models
{
    public class Specialization
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<SchoolEntity> SchoolEntities { get; set; }
    }
}
