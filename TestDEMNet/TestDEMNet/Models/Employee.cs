using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDEMNet.Models
{
    [Table("employees")]
    public class Employee
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public DateOnly Birthday { get; set; }
        public string? Passport { get; set; }
        public string? PaymentData { get; set; }
        public bool HasFamily { get; set; }
        public string? HealthState { get; set; }
    }

}
