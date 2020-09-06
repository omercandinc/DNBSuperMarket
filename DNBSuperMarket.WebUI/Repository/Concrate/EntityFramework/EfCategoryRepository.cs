using DNBSuperMarket.WebUI.Entity;
using DNBSuperMarket.WebUI.Models;
using DNBSuperMarket.WebUI.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DNBSuperMarket.WebUI.Repository.Concrate.EntityFramework
{
    public class EfCategoryRepository : EfGenericRepository<Category>, ICategoryRepository
    {
        public EfCategoryRepository(DNBSuperMarketContext context) : base(context)
        {

        }

        public DNBSuperMarketContext DNBSuperMarketContext
        {
            get { return context as DNBSuperMarketContext; }
        }

        public IEnumerable<CategoryModel> GetAllWithProductCount()
        {
            return GetAll().Select(i => new CategoryModel()
            {
                CategoryId = i.CategoryId,
                CategoryName = i.CategoryName,
                Count = i.ProductCategories.Count()
            });
        }

        public Category GetByName(string name)
        {
            return DNBSuperMarketContext.Categories
                .Where(i => i.CategoryName == name)
                .FirstOrDefault();
        }
    }
}
