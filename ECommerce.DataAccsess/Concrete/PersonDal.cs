using ECommerce.DataAccsess.Abstract;
using ECommerce.EntityFramework.Concrete;
using ECommerce.FrameworkCore.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccsess.Concrete
{
    public class PersonDal : RepositoryBase<Person>, IPersonDal
    {
        public ECommerceContext _eCommerceContext { get => _dbContext as ECommerceContext; }
        public PersonDal(DbContext context) : base(context)
        {
        }

        public List<Customer> GetAllCustomers()
        {
            return _eCommerceContext.Set<Person>().Where(v => EF.Property<string>(v, "Discriminator") == nameof(Customer)).Cast<Customer>().ToList();
        }
    }
}
