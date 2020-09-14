using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.EntityFramework.Concrete
{
    public class Shipper:Entity
    {
        public int ShipperId { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public virtual List<Order> Order { get; set; }
    }
}
