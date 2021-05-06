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
using TreinamentoWeb.Core.Interfaces;
using TreinamentoWeb.Core.Entities;
using FluentValidation;
using TreinamentoWeb.Services.Validators;

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

            services.AddScoped<IValidator<Product>, ProductValidator>();
            services.AddScoped<IValidator<LegalPerson>, LegalPersonValidator>();
            services.AddScoped<IValidator<NaturalPerson>, NaturalPersonValidator>();            

            services.AddScoped<IRepository<LegalPerson>, LegalPersonRepository>();
            services.AddScoped<IRepository<NaturalPerson>, NaturalPersonRepository>();
            services.AddScoped<IRepository<Product>, ProductRepository>();
            services.AddScoped<IService<LegalPerson>, LegalPersonService>();
            services.AddScoped<IService<NaturalPerson>, NaturalPersonService>();
            services.AddScoped<IService<Product>, ProductService>();
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
