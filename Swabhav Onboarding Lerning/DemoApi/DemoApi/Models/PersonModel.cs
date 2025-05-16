using System.ComponentModel.DataAnnotations;

namespace DemoApi.Models
{
    public class PersonModel
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
