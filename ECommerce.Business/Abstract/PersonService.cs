using ECommerce.DataAccsess.Abstract;
using ECommerce.EntityFramework.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public abstract class PersonService : IService<Customer>
    {
        public IPersonDal _personDal;
        public PersonService(IPersonDal personDal)
        {
            _personDal = personDal;
        }

        public abstract List<Customer> GetAllCustomers();



}
}
