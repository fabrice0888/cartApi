namespace ProductAPI.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProductAPI.Models.CartContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ProductAPI.Models.CartContext context)
        {
            

            context.Products.AddOrUpdate( p=> p.Id,
                new Product { Id = 1, Name = "DVD Writer", Category = "Electronics", Price = 100 },
                new Product { Id = 2, Name = "BluRay Writer", Category = "Electronics", Price = 200 },
                new Product { Id = 3, Name = "Key Board", Category = "Electronics", Price = 50 },
                new Product { Id = 4, Name = "Graphic Card", Category = "Electronics", Price = 300 },
                new Product { Id = 5, Name = "LCD Display", Category = "Electronics", Price = 125 }
                );


            context.Customers.AddOrUpdate(p => p.Id,
               new Customer { Id = 1, FirstName = "John", LastName = "Doe" }
                );

      


        }
    }
}
