using System.ComponentModel.DataAnnotations;

namespace Form.Model
{
    public class MyForm
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmedPassword { get; set; }
    }
}
