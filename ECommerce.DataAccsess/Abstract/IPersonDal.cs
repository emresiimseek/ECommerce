using ECommerce.EntityFramework.Concrete;
using ECommerce.FrameworkCore.Abstract;
using ECommerce.FrameworkCore.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccsess.Abstract
{
    public interface IPersonDal:IRepository<Person>
    {
     List<Customer> GetAllCustomers();
    }
}
