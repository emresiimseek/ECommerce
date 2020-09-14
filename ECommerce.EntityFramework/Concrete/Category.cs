using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.EntityFramework.Concrete
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
