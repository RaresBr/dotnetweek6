using Busines;
using Data.Domain.Interfaces;
using Data.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kata3
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
            services.AddTransient<IDatabaseContext, DatabaseContext>();
            services.AddTransient<IMenuCardRepository, MenuCardRepository>();

            //services.AddDbContext<DatabaseContext>(opts => opts.UseInMemoryDatabase("TodosList"));

            const string connection = @"Server = .\RARESPC; Database = MenuCards.Development; Trusted_Connection = true;";
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connection));

            services.AddMvc();
            // Register the Swagger generator, defining one or more Swagger documents
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
           

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
