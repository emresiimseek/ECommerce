using ECommerce.Business.Abstract;
using ECommerce.EntityFramework.Concrete;
using ECommerce.EntityFramework.Concrete.DTOs;
using ECommerce.FrameworkCore.Utilities.Mappings;
using ECommerce.WebAPI.Filters.FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private PersonService _personService;
        private IAutoMapper _autoMapper;

        public AuthenticationController(PersonService personService, IAutoMapper autoMapper)
        {
            _personService = personService;
            _autoMapper = autoMapper;
        }

        // GET: api/<AuthenticationController>
        [HttpPost]
        [ValidationFilter]
        public async Task<IActionResult> Authenticate(PersonDto personDto)
        {
            Person result = await _personService.Authenticate(personDto.UserName,personDto.Password);
            return Ok(_autoMapper.MapToSameTpe<Person, PersonDto>(result));
        }


    }
}
