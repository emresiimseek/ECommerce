using ECommerce.DataAccsess.Abstract;
using ECommerce.EntityFramework.Concrete;
using ECommerce.FrameworkCore.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.DataAccsess.Concrete
{
    public class ProductDal : RepositoryBase<Product>, IProductDal
    {
        private ECommerceContext eCommerceContext { get => _dbContext as ECommerceContext; }
        public ProductDal(DbContext context) : base(context)
        {

        }
    }
}
