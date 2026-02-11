using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace demo.api.Models
{
    [Table("prodTbl")]
    public class ProductModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int prodId { get; set; }
        public string prodName { get; set; } = string.Empty;
        public string shortName { get; set; } = string.Empty;
        public double price { get; set; } 
        public string category { get; set; } = string.Empty;  
    }

    [Table("prodImageTbl")]
    public class ProductImageModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int prodImageId { get; set; }
        public int prodId { get; set; } 
        public string imageName { get; set; } = string.Empty;
        public bool isActive { get; set; }  
    }

    public class ProductViewModel
    {
        public int prodId { get; set; }
        public string prodName { get; set; } = string.Empty;
        public string shortName { get; set; } = string.Empty;
        public double price { get; set; }
        public string category { get; set; } = string.Empty;

        public List<ProductImageModel> prodImages { get; set; } = new List<ProductImageModel>();
       
    }
}
