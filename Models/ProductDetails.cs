using System.ComponentModel.DataAnnotations;

namespace Dashboard.Models
{
    public class ProductDetails
    {
        [Key]
        public int id { get; set; }
        public int Productid { get; set; }
        public string Description { get; set; } 
         public double Price { get; set; }
        public string Model { get; set; }
        public string color { get; set; }
        public int Qty { get; set; }
        public string imag { get; set; }
       
    }
}
