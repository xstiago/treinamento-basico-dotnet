using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using TreinamentoWeb.Infra.Context;
using TreinamentoWeb.Infra.Repositories;
using TreinamentoWeb.Services.Services;
using Microsoft.Data.Sqlite;

namespace TreinamentoWeb.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TreinamentoWeb", Version = "v1" });
            });

            var connectionString = "DataSource=treinamento;mode=memory;cache=shared";
            new SqliteConnection(connectionString).Open();
            services.AddDbContext<AppDbContext>(options => { options.UseSqlite(connectionString); });

            services.AddScoped<CustomerRepository>();
            services.AddScoped<CustomerService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDbContext context)
        {
            context.Database.EnsureCreated();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TreinamentoWeb v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
