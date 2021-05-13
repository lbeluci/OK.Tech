using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OK.Tech.App;
using OK.Tech.Domain.Apps;
using OK.Tech.Domain.Notifications;
using OK.Tech.Domain.Repositories;
using OK.Tech.Infra.Data.Contexts;
using OK.Tech.Infra.Data.Repositories;

namespace OK.Tech.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApiDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<IProductApp, ProductApp>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IPriceListApp, PriceListApp>();
            services.AddScoped<IPriceListRepository, PriceListRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<INotifier, Notifier>();

            services.AddControllers();

            services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
