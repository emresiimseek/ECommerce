using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ECommerce.EntityFramework.Concrete
{
    public class OrderDetail:Entity
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public  virtual Order Order { get; set; }
        public  virtual Shipper Shipper { get; set; }

    }
}
