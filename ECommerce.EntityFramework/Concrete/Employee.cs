using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.EntityFramework.Concrete
{
    public class Employee : Person
    {
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
