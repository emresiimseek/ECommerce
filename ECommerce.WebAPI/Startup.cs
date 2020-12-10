using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Business.Abstract;
using ECommerce.Business.Concrete;
using ECommerce.Business.ValidationRules.FluentValidation;
using ECommerce.Data.Concrete;
using ECommerce.DataAccsess;
using ECommerce.DataAccsess.Abstract;
using ECommerce.DataAccsess.Concrete;
using ECommerce.EntityFramework.Concrete;
using ECommerce.EntityFramework.Concrete.DTOs;
using ECommerce.FrameworkCore.Abstract;
using ECommerce.FrameworkCore.Concrete;
using ECommerce.FrameworkCore.Utilities.Mappings;
using ECommerce.WebAPI.Filters;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace ECommerce.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //ConnectionsStr Configurations
            services.AddDbContextPool<ECommerceContext>(options =>
            {
                options.UseMySql(Configuration.GetConnectionString("MySqlConStr"));
            });


            //Fluent Validation Configurations
            services.AddMvc(setup =>
            {
                //...mvc setup...
            }).AddFluentValidation();
            services.AddTransient<IValidator<CustomerDto>, CustomerValidator>();
            services.AddTransient<IValidator<PersonDto>, PersonValidator>();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            //jwt
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            //configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            //DI Configurations
            services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<DbContext, ECommerceContext>();
            services.AddScoped(typeof(IPersonDal), typeof(PersonDal));
            services.AddScoped(typeof(PersonService), typeof(CustomerManager));
            services.AddScoped(typeof(IAutoMapper), typeof(AutoMapperBase));
            services.AddScoped(typeof(IService<Customer>), typeof(CustomerManager));
            services.AddScoped(typeof(IsExistFilter<>));






        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
