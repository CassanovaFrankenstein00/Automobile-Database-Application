using System.ComponentModel.DataAnnotations;
using System.Net.Cache;
namespace AutoCollection.Models
{
    public enum Type
    {
        Sedan,
        Convertable,
        Truck,
        SUV,
        StationWagon 

    }
    public class Automobile
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Make { get; set; }
        [Required]
        [StringLength(255)]
        public string Model { get; set; }
        [Required]
        public int Year { get; set; }
        [EnumDataType(typeof(Type))]
        public Type? Type { get; set; }
        public float? Price { get; set; }
        public int? Age { get; set; }
    }
}
