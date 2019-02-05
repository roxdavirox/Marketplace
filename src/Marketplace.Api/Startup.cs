using Marketplace.Api.Filters;
using Marketplace.App.Notifications;
using Marketplace.Domain.Interfaces.Repositories;
using Marketplace.Infra.Data.EF.Context;
using Marketplace.Infra.Data.Repositories;
using Marketplace.Infra.IoC.Containers;
using Marketplace.Infra.Transactions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Marketplace.Api
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
            services.AddMvc(options => options.Filters.Add<AsyncFilterResult>())
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddMediatRDependencyHandlers();

            services.AddScoped<MarketplaceContext, MarketplaceContext>();

            services.AddScoped<NotificationContext, NotificationContext>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IOptionRepository, OptionRepository>();
            services.AddTransient<IItemRepository, ItemRepository>();
            services.AddTransient<IPriceRepository, PriceRepository>();

            services.AddSwaggerGen(c =>
               c.SwaggerDoc("v1", new Info { Title = $"Marketplace API - {Configuration["ConnectionString"]}", Version = "v1" })
           );
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Marketplace API v1")
            );

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
