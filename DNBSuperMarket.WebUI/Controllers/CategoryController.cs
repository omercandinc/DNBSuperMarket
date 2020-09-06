using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNBSuperMarket.WebUI.Repository.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DNBSuperMarket.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryRepository repository;
        private IUnitOfWork uow;

        public CategoryController(IUnitOfWork _uow, ICategoryRepository _repository)
        {
            repository = _repository;
            uow = _uow;
        }
        // GET: CategoryController
        public IActionResult Index()
        {
            return View(repository.GetAll());
        }

        public IViewComponentResult Invoke()
        {
            return (IViewComponentResult)View(uow.Categories.GetAllWithProductCount());
        }

    }
}
