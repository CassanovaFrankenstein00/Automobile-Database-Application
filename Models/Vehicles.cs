using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Automobiles.Models
{
    public class Vehicles
    {
        public int Id { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(30)]
        public string Make {  get; set; }
        [StringLength(30)]
        public string Model { get; set; }
        public int Year { get; set; }
        public string Type { get; set; }
        [Range(1, 10000000)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; } = 0;
        public string Description { get; set; }
    }
}
