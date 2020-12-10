using ECommerce.Data.Concrete;
using ECommerce.DataAccsess.Abstract;
using ECommerce.EntityFramework.Concrete;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public abstract class PersonService : IService<Customer>
    {
        public IPersonDal _personDal;
        public IPersonDal personDal;
        private readonly AppSettings _appSettings;
        public PersonService(IPersonDal personDal, IOptions<AppSettings> appSettings)
        {
            _personDal = personDal;
            _appSettings = appSettings.Value;
        }

        public abstract List<Customer> GetAllCustomers();

        public async Task<Person> Authenticate(string username, string password)
        {

            var result = await _personDal.GetAsync(p => p.UserName == username && p.Password == password);
            if (result == null)
                return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] { new Claim("id", result.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256)

            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            result.Token = tokenHandler.WriteToken(token);
            result.Password = null;
            return result;

        }



    }
}
