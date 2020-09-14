﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.EntityFramework.Concrete
{
    public class Supplier:Entity
    {
        public int SupplierId { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle{ get; set; }
        public string Address{ get; set; }
        public string City{ get; set; }
        public string Region{ get; set; }
        public string ZipCode{ get; set; }
        public string Country{ get; set; }
        public string Phone{ get; set; }
        public string Fax{ get; set; }
        public string WebSite{ get; set; }
        public virtual List<Product>  Products { get; set; }
    }
}