using System.ComponentModel.DataAnnotations;

namespace Dashboard.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }

        public string IdCostumer { get; set; }

        public int IdProduct { get; set;}

       public string ProductName { get; set;}
        
        public double Price { get; set;}

        public string Images { get; set;}

        public double Total { get; set; }

        public int QTY { get; set;}

       
         
        public double Tax { get; set;}
    }
}
