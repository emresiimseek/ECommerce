using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.EntityFramework.Concrete
{
    public class Customer : Person
    {
        public virtual List<Order> Orders { get; set; }

    }
}
