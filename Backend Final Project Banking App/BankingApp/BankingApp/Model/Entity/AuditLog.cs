using System.ComponentModel.DataAnnotations;

namespace BankingApp.Model.Entity
{
    public class AuditLog
    {
        [Key]
        public int AuditId { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }
        public DateTime Time {  get; set; }
    }
}
