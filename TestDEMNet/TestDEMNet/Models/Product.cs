using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDEMNet.Models
{
    [Table("products")]
    public class Product
    {
        public int Id { get; set; }
        public string? VendorCode { get; set; }
        public string? Type { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Standard { get; set; }
        public string? ProductionNumber { get; set; }
        public float? MinimalPartnerCost { get; set; }
        public float? FactCost { get; set; }
        public float? Length { get; set; }
        public float? Width { get; set; }
        public float? Height { get; set; }
        public float? MassWithoutBox { get; set; }
        public float? MassWithBox { get; set; }
        public DateTime ManufactureTime { get; set; }
    }

}
