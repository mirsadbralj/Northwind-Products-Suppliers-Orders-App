using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using Northwind.Database;
using Northwind.Service;
using Northwind.Service.Category;
using Northwind.Service.Order;
using Northwind.Service.OrderDetail;
using Northwind.Service.Product;
using Northwind.Service.Supplier;
using NorthwindModel.Requests.Category;
using NorthwindModel.Requests.Order;
using NorthwindModel.Requests.OrderDetails;
using NorthwindModel.Requests.Product;
using NorthwindModel.Requests.Supplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind
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
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod()
                 .AllowAnyHeader());
            });
            services.AddControllers();

            services.AddSwaggerGen();
            services.AddAutoMapper(typeof(Startup));
            services.AddRouting();

            //JSON Serializer
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft
                .Json.ReferenceLoopHandling.Ignore)
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver
                = new DefaultContractResolver());


            services.AddDbContext<NORTHWNDContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("NORTHWNDContext")));

            services.AddScoped<ICRUDService<NorthwindModel.Product, ProductSearchRequest, ProductUpsertRequest, ProductUpsertRequest>, ProductService>();
            services.AddScoped<ICRUDService<NorthwindModel.Supplier, SupplierSearchRequest, SupplierUpsertRequest, SupplierUpsertRequest>, SupplierService>();
            services.AddScoped<ICRUDService<NorthwindModel.Order, OrderSearchRequest, OrderUpsertRequest, OrderUpsertRequest>, OrderService>();
            services.AddScoped<ICRUDService<NorthwindModel.Category, CategorySearchRequest, CategoryUpsertRequest, CategoryUpsertRequest>, CategoryService>();
            services.AddScoped<ICRUDService<NorthwindModel.OrderDetail, OrderDetailSearchRequest, OrderDetailUpsertRequest, OrderDetailUpsertRequest>, OrderDetailService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            
            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute("default", "{controller=ProductController}/{action=Get}");
                endpoints.MapControllers();
                // Create routes for Web API and SignalR here too..
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Northwind");
            });

        }
    }
}
