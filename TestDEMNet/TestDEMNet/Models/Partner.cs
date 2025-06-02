using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDEMNet.Models
{
    [Table("partners")]
    public class Partner
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public string? CompanyName { get; set; }
        public string? Address { get; set; }
        public string? Inn { get; set; }
        public string? DirectorName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public int Rating { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }

}
