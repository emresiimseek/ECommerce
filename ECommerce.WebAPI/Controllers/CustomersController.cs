using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Business.Abstract;
using ECommerce.EntityFramework.Concrete;
using ECommerce.EntityFramework.Concrete.DTOs;
using ECommerce.FrameworkCore.Utilities.Mappings;
using ECommerce.WebAPI.Filters;
using ECommerce.WebAPI.Filters.FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private IAutoMapper _autoMapper;
        private PersonService _personService { get; set; }
        public CustomersController(PersonService personService, IAutoMapper autoMapper)
        {
            _personService = personService;
            _autoMapper = autoMapper;
        }

        [HttpPost]
        [ValidationFilter]
        public async Task<IActionResult> Save(CustomerDto customerDto)
        {
            Person customer = await _personService.AddAsync(_autoMapper.MapToSameTpe<CustomerDto, Customer>(customerDto));
            return Created(string.Empty, _autoMapper.MapToSameTpe<Person, CustomerDto>(customer));
        }
        [HttpPut("{id}")]
        [ValidationFilter]
        [ServiceFilter(typeof(IsExistFilter<Customer>))]
        public IActionResult Update([FromBody]CustomerDto customerDto,int id)
        {
            _personService.Update(_autoMapper.MapToSameTpe<CustomerDto, Customer>(customerDto));
            return NoContent();
        }
        [HttpDelete("{id}")]
        [ServiceFilter(typeof(IsExistFilter<Customer>))]
        public IActionResult Delete(int id)
        {
            _personService.DeleteById(id);
            return NoContent();
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Customer> customers = _personService.GetAllCustomers();
            return Ok(_autoMapper.MapToSameList<Customer, CustomerDto>(customers));
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(IsExistFilter<Customer>))]
        public async Task<IActionResult> GetById(int id)
         {
            return Ok(_autoMapper.MapToSameTpe<Person, CustomerDto>(await _personService.GetByIdAsync(id)));
        }
    }
}
