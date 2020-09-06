using DNBSuperMarket.WebUI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DNBSuperMarket.WebUI.Repository.Abstract
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        List<Product> GetTop5Products();
    }
}
