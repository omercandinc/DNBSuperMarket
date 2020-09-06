using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNBSuperMarket.WebUI.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace DNBSuperMarket.WebUI.Controllers
{
    public class ProductController : Controller
    {
        public int PageSize = 3;
        private IProductRepository repository;
        public ProductController(IProductRepository _repository)
        {
            repository = _repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List(string category,int page=1)
        {
            var products = repository.GetAll();
            
            if(!string.IsNullOrEmpty(category))
            {
                products = products
                    .Include(i => i.ProductCategories)
                    .ThenInclude(i => i.Category)
                    .Where(i => i.ProductCategories.Any(a=>a.Category.CategoryName==category));
            }

            products = products.Skip((page-1)*PageSize).Take(PageSize);

            return View(products);
        }

       
    }
}
