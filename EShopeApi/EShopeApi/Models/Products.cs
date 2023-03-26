using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EShopeApi.Models
{
    public class Products
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public string? ProductBrand { get; set; }
        public int? ProductCount { get; set; }
        public double? Price { get; set; }
        // public IFormFile?Productimage { get; set; }


    }
}
