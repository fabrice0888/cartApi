using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAPI.Models
{

    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }

    }


    public class Order    { 
        
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string OrderReference { get; set; }
        public DateTime OrderDate { get; set; } 
        public string Status { get; set; } //Open  Closed     
        public double Total { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual Customer Customer { get; set; }
    }

 
    public class OrderDetail
    {
    
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double UnitCost { get; set; }
        public double Amount { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }


    public class CartView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double UnitCost { get; set; }
        public double Amount { get; set; }
    }

}
