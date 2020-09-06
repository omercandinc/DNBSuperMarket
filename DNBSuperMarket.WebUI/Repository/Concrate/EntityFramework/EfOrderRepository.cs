using DNBSuperMarket.WebUI.Entity;
using DNBSuperMarket.WebUI.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DNBSuperMarket.WebUI.Repository.Concrate.EntityFramework
{
    public class EfOrderRepository : EfGenericRepository<Order>, IOrderRepository
    {
        public EfOrderRepository(DNBSuperMarketContext context) : base(context)
        {
        }
    }
}
