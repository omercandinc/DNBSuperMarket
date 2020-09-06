using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNBSuperMarket.WebUI.Entity;
using DNBSuperMarket.WebUI.Models;
using DNBSuperMarket.WebUI.Repository.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DNBSuperMarket.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        public int PageSize = 20;
        private IProductRepository repository;
        private ICategoryRepository categoryRepository;

        public AdminController(IProductRepository _repository, ICategoryRepository _categoryRepository)
        {
            repository = _repository;
            categoryRepository = _categoryRepository;
        }

        public IActionResult List(int page = 1)
        {
            var products = repository.GetAll();
            var count = products.Count();

            products = products.Skip((page - 1) * PageSize).Take(PageSize);

            return View(
                new ProductListModel()
                {
                    Products = products,
                    PagingInfo = new PagingInfo()
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = count
                    }
                }
                );
        }

        public IActionResult EditProduct(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = repository.Get(id);

            if (entity == null)
            {
                return NotFound();
            }

            var model = new Product();
           
            model.ProductId = entity.ProductId;
            model.ProductName = entity.ProductName;
            model.Price = entity.Price;
            model.StockQuantity = entity.StockQuantity;
            model.Description = entity.Description;
            model.DateAdded = entity.DateAdded;

            ViewBag.Categories = categoryRepository.GetAll();

            return View(model);
        }

        [HttpPost]
        public IActionResult EditProduct(Product model)
        {
            if (ModelState.IsValid)
            {
                var entity = repository.Get(model.ProductId);

                if (entity == null)
                {
                    return NotFound();
                }

                entity.ProductName = model.ProductName;
                entity.StockQuantity = model.StockQuantity;
                entity.Price = model.Price;
                entity.Description = model.Description;
                entity.DateAdded = model.DateAdded;


                repository.Edit(entity);
                repository.Save();

                return RedirectToAction("List");
            }
            return View(model);
        }

        public IActionResult DeleteProduct(int id)
        {
            var product = repository.Get(id);

            if(product != null)
            {
                repository.Delete(product);
                repository.Save();
                return Json(null);
            }

            else
            {
                return NotFound();
            }
            
            
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.Add(product);
                repository.Save();
                return RedirectToAction("List");
            }
            return View(product);
        }
    }
}
