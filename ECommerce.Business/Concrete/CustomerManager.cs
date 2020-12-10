using ECommerce.Business.Abstract;
using ECommerce.Data.Concrete;
using ECommerce.DataAccsess.Abstract;
using ECommerce.DataAccsess.Concrete;
using ECommerce.EntityFramework.Concrete;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrete
{
    public class CustomerManager : PersonService
    {
        public CustomerManager(IPersonDal personDal, IOptions<AppSettings> appSettings) : base(personDal, appSettings)
        {

        }

        public override async Task<Customer> AddAsync(Customer Entity)
        {
            return await _personDal.AddAsync(Entity) as Customer;
        }

        public override void Delete(Customer Entity)
        {
            _personDal.Delete(Entity);
        }

        public override void DeleteById(object EntityId)
        {
            _personDal.DeleteById(EntityId);
        }

        public override IEnumerable<Customer> GetAll()
        {
            return (IEnumerable<Customer>)_personDal.GetAll(null);
        }

        public override List<Customer> GetAllCustomers()
        {
            return _personDal.GetAllCustomers();
        }

        public override async Task<Customer> GetAsync()
        {
            return await _personDal.GetAsync(null) as Customer;
        }

        public override async Task<Customer> GetByIdAsync(int id)
        {
            return await _personDal.GetByIdAsync(id) as Customer;
        }

        public override void Update(Customer Entity)
        {
            _personDal.Update(Entity);
        }
    }
}
