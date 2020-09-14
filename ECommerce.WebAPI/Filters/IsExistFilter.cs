using ECommerce.Business.Abstract;
using ECommerce.EntityFramework.Concrete;
using ECommerce.EntityFramework.Concrete.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.WebAPI.Filters
{
    public class IsExistFilter<T> : IAsyncActionFilter
    {
        public IService<T> _service { get; set; }
        public IsExistFilter(IService<T> service)
        {
            _service = service;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int Id = (int)context.ActionArguments.Values.Last();
            var result = await _service.GetByIdAsync(Id);
            if (result == null)
            {
                ErrorDto errorDto = new ErrorDto();
                errorDto.StatusCode = 400;
                errorDto.Errors.Add($"{Id} id'li nesne bulunmadı!");


                context.Result = new NotFoundObjectResult(errorDto);
            }
            else
            {
                await next();
            }
           
        }
    }
}
