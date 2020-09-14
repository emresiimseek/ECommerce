using ECommerce.DataAccsess.Abstract;
using ECommerce.EntityFramework.Concrete;
using ECommerce.FrameworkCore.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.DataAccsess.Concrete
{
    public class OrderDetailDal : RepositoryBase<OrderDetail>, IOrderDetailDal
    {
        public ECommerceContext eCommerceContext { get => _dbContext as ECommerceContext; }

        public OrderDetailDal(DbContext context):base(context)
        {

        }

    }
}
