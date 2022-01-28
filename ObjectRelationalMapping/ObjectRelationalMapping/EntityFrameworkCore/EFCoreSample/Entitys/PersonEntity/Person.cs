using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSample.Entitys.PersonEntity
{
    [Table("T_Person")]
    public class Person
    {
        [Key] public long PersonId { get; set; }
        [Required] [MaxLength(50)] public string? Name { get; set; }
        public int Age { get; set; }
        [Required] public bool Sex { get; set; }
    }
}