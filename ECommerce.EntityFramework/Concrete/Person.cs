using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.EntityFramework.Concrete
{
    public class Person: Entity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }


    }
}
