using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SnackStoreV3.Commons;
using SnackStoreV3.Domain.Interfaces;
using SnackStoreV3.Domain.Models;
using SnackStoreV3.Domain.services;
using SnackStoreV3.Repository;
using SnackStoreV3.Validator;
using Swashbuckle.AspNetCore.Swagger;

namespace SnackStoreV3
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
           

            var connectionString = Configuration.GetConnectionString("SnackStoreConnection");
            //services.AddDbContext<StoreDbContext>(opt => opt.UseSqlServer(connectionString));
            services.AddDbContext<StoreDbContext>(opt => opt.UseInMemoryDatabase("SnackStore"));
       
            services.AddScoped<ISnackRepository, SnackRepository>();
            services.AddScoped<IUserAccountRepository, UserAccountRepository>();
            services.AddScoped<ILogPriceRepository, LogPriceRepository>();
            services.AddScoped<ILogPurchaseRepository, LogPurchaseRepository>();
            services.AddScoped<IBuySnacks , BuySnackService>();
            services.AddSingleton<ItokenFactory, JwtFactory>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddTransient<IValidator<SnackModel>, EntityToValidateValidator>();
            services.AddHttpContextAccessor();

            //agrego swagger documentacion
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info {
                    Title = "oafigueroa",
                    Version = "v1",
                    Description = "",
                    TermsOfService="",
                    Contact= new Contact
                    {
                        Name="Oscar Figueroa",
                        Email="ofigueroa.ca@gmail.com"
                    }

                }); 
                
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    var signingKey = Convert.FromBase64String(Configuration["Jwt:SigningSecret"]);
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(signingKey)
                    };
                });


        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
            
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            //// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            //// specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Store Documentation API");
            });
        }
    }
}
