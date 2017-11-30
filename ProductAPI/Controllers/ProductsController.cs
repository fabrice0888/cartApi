using ProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace ProductAPI.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {

        private CartContext db = new CartContext();

        [Route("")]
        public IEnumerable<Product> GetAllProducts()
        {

            return db.Products.ToList();
        }

        [Route("{id:int}")]
        public IHttpActionResult GetProductById(int id)
        {
           

            var product = db.Products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [Route("{name}")]
        public IEnumerable<Product> GetProductByName(string name)
        {
           
            var product = db.Products.Where(x => x.Name.Contains(name)).ToList();
            return product;
        }


        [HttpPost]
        [Route("~/api/order/{id:int}")]       
        [ResponseType(typeof(Order))]
        public IHttpActionResult PostProductOrder(int Id)
        {

            var product = db.Products.Where(x => x.Id == Id).FirstOrDefault();

            if (product==null)
            {
                return NotFound();
            }
            var order = db.Orders.Where(x => x.CustomerId == 1).FirstOrDefault();
            var testUser = db.Customers.Where(x => x.Id == 1).FirstOrDefault();
     

            if (order == null )
            {
                order = new Models.Order();

                order.OrderDate = DateTime.Now;
                order.Status = "Open";
                order.CustomerId = testUser.Id;
                order.Customer = testUser;
             
            }
             

         

            OrderDetail ordDet = db.OrderDetails.Where(x => x.ProductId == Id).FirstOrDefault();

            if(ordDet==null)
            {
                ordDet = new OrderDetail();
                ordDet.Amount = product.Price;
                // ordDet.OrderId = order.Id;
                // ordDet.ProductId = product.Id;
                ordDet.Quantity = 1;
                ordDet.UnitCost = product.Price;
                ordDet.Order = order;
                ordDet.Product = product;

                db.OrderDetails.Add(ordDet);
            }
            else
            {
                ordDet.Quantity = ordDet.Quantity + 1;
                ordDet.Amount = ordDet.Quantity * ordDet.UnitCost;
            }
         

            db.SaveChanges();

            order.OrderDetails = null;

            return CreatedAtRoute("DefaultApi", new { controller = "products", id = order.Id }, ordDet);
        }


        [Route("~/api/orders")]
        public IEnumerable<CartView> GetOrders()
        {

            var orders = db.OrderDetails.Where(x => x.Order.CustomerId == 1).Select(x=> new CartView {
                Id = x.Id,
                Name = x.Product.Name,
                Quantity = x.Quantity,
                UnitCost = x.UnitCost,
                Amount = x.Amount
            
            }).ToList();

            return orders;
        }

        [HttpDelete]
        [ResponseType(typeof(void))]
        [Route("~/api/orders/clear")]  
        public IHttpActionResult DeleteOrders()
        {

            var clearOrders = db.Orders.Where(x => x.CustomerId == 1).ToList();
            var clearOrderDetails = db.OrderDetails.Where(x => x.Order.CustomerId == 1).ToList();

            db.OrderDetails.RemoveRange(clearOrderDetails);
            db.Orders.RemoveRange(clearOrders); 

            db.SaveChanges();


            return Ok();
        }


        [HttpPut]
        [Route("~/api/order/{id:int}/quantity/{qty:int}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrderQuantity(int Id, int qty)
        {

            OrderDetail ordDet = db.OrderDetails.Where(x => x.Id == Id).FirstOrDefault();

            if (ordDet == null)
            {
                return NotFound();
            }
            else
            {
                if(qty<=0)
                {
                    db.OrderDetails.Remove(ordDet);
                }
                else
                {
                    ordDet.Quantity = qty;
                    ordDet.Amount = ordDet.Quantity * ordDet.UnitCost;
                }
              
            }


            db.SaveChanges();

            return Ok();
        }

    }
}
