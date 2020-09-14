using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.EntityFramework.Concrete.DTOs
{
    public class ErrorDto
    {
        public ErrorDto()
        {
            Errors = new List<string>();
        }
        public int StatusCode { get; set; }
        public List<string> Errors { get; set; }
    }
}
