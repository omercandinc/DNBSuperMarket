using DNBSuperMarket.WebUI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNBSuperMarket.WebUI.Repository.Abstract
{
    public interface IOrderLineRepository:IGenericRepository<OrderLine>
    {
        void ClearAll();
    }
}
