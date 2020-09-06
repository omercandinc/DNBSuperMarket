using DNBSuperMarket.WebUI.Entity;
using DNBSuperMarket.WebUI.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DNBSuperMarket.WebUI.Repository.Concrate.EntityFramework
{
    public class EfProductRepository : EfGenericRepository<Product>, IProductRepository
    {
        public EfProductRepository(DNBSuperMarketContext context) : base(context)
        {

        }

        public DNBSuperMarketContext DNBSuperMarketContext
        {
            get { return context as DNBSuperMarketContext; }
        }

        public List<Product> GetTop5Products()
        {
            return DNBSuperMarketContext.Products
                .OrderByDescending(i => i.ProductId)
                .Take(5)
                .ToList();
        }
    }
}
