using DNBSuperMarket.WebUI.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNBSuperMarket.WebUI.Repository.Concrate.EntityFramework
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly DNBSuperMarketContext dbContext;
        public EfUnitOfWork(DNBSuperMarketContext _dbContext)
        {
            dbContext = _dbContext ?? throw new ArgumentNullException("dbcontext can not be null");
        }

        private IProductRepository _products;
        private ICategoryRepository _categories;
        private IOrderRepository _orders;
        private IOrderLineRepository _orderLine;


        public IProductRepository Products
        {
            get
            {
                return _products ?? (_products = new EfProductRepository(dbContext));
            }
        }

        public ICategoryRepository Categories
        {
            get
            {
                return _categories ?? (_categories = new EfCategoryRepository(dbContext));
            }
        }

        public IOrderRepository Orders
        {
            get
            {
                return _orders ?? (_orders = new EfOrderRepository(dbContext));
            }
        }

        public IOrderLineRepository OrderLine
        {
            get
            {
                return _orderLine ?? (_orderLine = new EfOrderLineRepository(dbContext));
            }
        }

        public int SaveChanges()
        {
            return dbContext.SaveChanges();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }


    }
}
