using ECommerce.DataAccsess.Abstract;
using ECommerce.EntityFramework.Concrete;
using ECommerce.FrameworkCore.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.DataAccsess.Concrete
{
    public class CategoryDal : RepositoryBase<Category>,ICategoryDal
    {
        public ECommerceContext _eCommerceContext { get => _dbContext as ECommerceContext; }

        public CategoryDal(DbContext context) : base(context)
        {

        }
    }
}
