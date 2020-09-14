using ECommerce.DataAccsess.Abstract;
using ECommerce.EntityFramework.Concrete;
using ECommerce.FrameworkCore.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.DataAccsess.Concrete
{
    public class OrderDal : RepositoryBase<Order>,IOrderDal
    {
        public ECommerceContext ECommerceContext   { get=>_dbContext as ECommerceContext; }
        public OrderDal(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
