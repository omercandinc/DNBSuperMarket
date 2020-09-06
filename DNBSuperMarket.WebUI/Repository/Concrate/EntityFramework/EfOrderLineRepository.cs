using DNBSuperMarket.WebUI.Entity;
using DNBSuperMarket.WebUI.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNBSuperMarket.WebUI.Repository.Concrate.EntityFramework
{
    public class EfOrderLineRepository : EfGenericRepository<OrderLine>, IOrderLineRepository
    {
        public EfOrderLineRepository(DNBSuperMarketContext context) : base(context)
        {
        }
        public DNBSuperMarketContext DNBSuperMarketContext
        {
            get { return context as DNBSuperMarketContext; }
        }
        public void ClearAll()
        {
            foreach (var entity in DNBSuperMarketContext.OrderLine)
                DNBSuperMarketContext.OrderLine.Remove(entity);
            DNBSuperMarketContext.SaveChanges();

        }



    }
}
