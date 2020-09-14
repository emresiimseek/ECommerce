using ECommerce.DataAccsess.Abstract;
using ECommerce.EntityFramework.Concrete;
using ECommerce.FrameworkCore.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.DataAccsess.Concrete
{
    public class ShipperDal : RepositoryBase<Shipper>, IShipperDal
    {
        public ECommerceContext eCommerceContext { get => _dbContext as ECommerceContext; }

        public ShipperDal(DbContext context) : base(context)
        {

        }
    }
}
