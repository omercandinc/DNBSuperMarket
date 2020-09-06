using DNBSuperMarket.WebUI.Entity;
using DNBSuperMarket.WebUI.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNBSuperMarket.WebUI.Models
{
    public class Cart
    {
        private List<CartLine> products = new List<CartLine>();
        public List<CartLine> Products => products;

        private IUnitOfWork unitofWork;

        public Cart(IUnitOfWork _unitofWork)
        {
            unitofWork = _unitofWork;
        }

        public void AddProduct(Product product, int quantity)
        {

        }

        public void RemoveProduct(Product product)
        {
            products.RemoveAll(i => i.Product.ProductId == product.ProductId);
        }

        public double TotalPrice()
        {
            return products.Sum(i => i.Product.Price * i.Quantity);
        }

        public void ClearAll()
        {
            products.Clear();
        }

    }
    public class CartLine
    {
        public int CartLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

    }
}
