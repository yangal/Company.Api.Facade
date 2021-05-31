using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Mwnz.Company.Facade.WebApi.Controllers.Filters;
using Mwnz.Company.Facade.WebApi.Controllers.Implementation;
using Mwnz.Company.Facade.WebApi.Controllers.Specification;
using Mwnz.Company.Facade.WebApi.Profiles;
using Mwnz.Company.Facade.WebApi.Services;
using Mwnz.Company.Source.Xml.Api.Clients;
using Mwnz.Company.Source.Xml.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mwnz.Company.Facade.WebApi
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
            services
               .AddMvc()
               .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddControllers(options => options.Filters.Add(new HttpResponseExceptionFilter()));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Company API", Version = "v1" });
            });
            services.AddAutoMapper(typeof(CompanyMappingProfiles));
            services.AddHttpClient<IClient, Client>(client => client.BaseAddress = new Uri(Configuration.GetValue<string>("COMPANY_SOURCE_XML_ENDPOINT")));
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ICompanyController, CompanyControllerImpl>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            Microsoft.AspNetCore.Builder.SwaggerBuilderExtensions.UseSwagger(app, null);

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Company API V1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
