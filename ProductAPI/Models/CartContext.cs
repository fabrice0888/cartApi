using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProductAPI.Models
{
    public class CartContext : DbContext
    {
         
    
        public CartContext() : base("name=CartContext")
        {
            Database.SetInitializer<CartContext>(new MigrateDatabaseToLatestVersion<CartContext, Migrations.Configuration>());
            //will migrate and seed db on first connection

            Configuration.LazyLoadingEnabled = false;
        }

        public System.Data.Entity.DbSet<ProductAPI.Models.Customer> Customers { get; set; }
        public System.Data.Entity.DbSet<ProductAPI.Models.Order> Orders { get; set; }
        public System.Data.Entity.DbSet<ProductAPI.Models.OrderDetail> OrderDetails { get; set; }
        public System.Data.Entity.DbSet<ProductAPI.Models.Product> Products { get; set; }

    }
}
