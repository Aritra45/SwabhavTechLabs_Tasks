using System.ComponentModel.DataAnnotations;

namespace MyFirstWwbApi.Model.Entity
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string PhoneNumber { get; set; }
        public required string salary { get; set; }

        public bool IsActive { get; set; }
    }
}
