using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNBSuperMarket.WebUI.Entity;
using DNBSuperMarket.WebUI.Infrastructure;
using DNBSuperMarket.WebUI.Models;
using DNBSuperMarket.WebUI.Repository.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DNBSuperMarket.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IUnitOfWork unitofWork;
        public CartController(IUnitOfWork _unitofWork)
        {
            unitofWork = _unitofWork;
        }
        public IActionResult Index()
        {
            var cart = unitofWork.OrderLine.GetAll().Where(i=>i.OrderState!="Bitti");
            ViewBag.Total = unitofWork.OrderLine.GetAll().Select(i => i.Price).DefaultIfEmpty().Sum();
            return View(unitofWork.OrderLine.GetAll().Where(i => i.OrderState != "Bitti"));
        }

        public IActionResult AddToCart(int ProductId, int quantity=1)
        {
            var orderLine = new OrderLine();
            var ProductorderLine = unitofWork.OrderLine.Get(ProductId);
            var Product = unitofWork.Products.Get(ProductId);

            if (ProductorderLine == null)
            {
                orderLine.ProductId = Product.ProductId;
                orderLine.Quantity = quantity;
                orderLine.Price = Product.Price;
                orderLine.ProductName = Product.ProductName;

                unitofWork.OrderLine.Add(orderLine);
            }
            else
            {
                ProductorderLine.Quantity += quantity ;
                unitofWork.OrderLine.Edit(ProductorderLine);
            }

            unitofWork.SaveChanges();


            return RedirectToAction("List", "Admin");
        }

        public IActionResult RemoveFromCart(int orderLineId)
        {
            var orderLine = new OrderLine();
            orderLine = unitofWork.OrderLine.Get(orderLineId);
           
            unitofWork.OrderLine.Delete(orderLine);
            unitofWork.SaveChanges();
            

            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Checkout(OrderDetails model)
        {
            if (ModelState.IsValid)
            {
                SaveOrder(model);
                return View("Completed");
            }

            return View(model);
        }

        private void SaveOrder( OrderDetails details)
        {
            var order = new Order();

            order.OrderNumber = "DNB" + (new Random()).Next(11111, 99999).ToString();
            order.Total = unitofWork.OrderLine.GetAll().Select(i => i.Price).DefaultIfEmpty().Sum();
            order.OrderDate = DateTime.Now;
            order.OrderState = EnumOrderState.Completed;
            order.Username = User.Identity.Name;

            order.AdresTanimi = details.AdresTanimi;
            order.Adres = details.Adres;
            order.Sehir = details.Sehir;
            order.Semt = details.Semt;
            order.Telefon = details.Telefon;

            foreach (var product in unitofWork.OrderLine.GetAll().Where(i=>i.OrderState!="Bitti"))
            {
                var orderline = new OrderLine();
                product.OrderState = "Bitti";
                product.OrderNumber = order.OrderNumber;
                unitofWork.OrderLine.Edit(product);
            }

            unitofWork.Orders.Add(order);
            unitofWork.SaveChanges();
        }
    }
}
