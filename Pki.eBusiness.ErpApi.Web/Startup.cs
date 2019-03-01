using System;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pki.eBusiness.ErpApi.Entities.Settings;
using Pki.eBusiness.ErpApi.Logger;
using Pki.eBusiness.ErpApi.Web.Attributes;
using Pki.eBusiness.ErpApi.Web.Filters;
using Swashbuckle.AspNetCore.Swagger;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace Pki.eBusiness.ErpApi.Web
{
    public class Startup
    {
        private const string SWAGGER_DOC_NAME = "Erp API";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
            services.AddMvc(config =>
            {
                config.Filters.Add(new ValidationExceptionFilterAttribute());
                config.Filters.Add(new IPLoggingFilter());
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1).AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.Converters.Add(new StringEnumConverter());
                //options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            }); 

            services.Scan(scan =>
            {
                var one = scan.FromApplicationDependencies(a => a.FullName.StartsWith("Pki.eBusiness.ErpApi", StringComparison.CurrentCulture));
                var two = one.AddClasses();
                var three = two.AsMatchingInterface();
            });

            var swaggerSettings = new SwaggerSettings();
            Configuration.Bind("SwaggerSettings", swaggerSettings);
            services.AddSingleton(swaggerSettings);
            var erpRestSettings = new ERPRestSettings();
            Configuration.Bind("ErpRestSettings", erpRestSettings);
            services.AddSingleton(erpRestSettings);
            var loggerConfiguration = new LoggerConfiguration();
            Configuration.Bind("LoggerConfiguration", loggerConfiguration);
            services.AddSingleton(loggerConfiguration);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = SWAGGER_DOC_NAME, Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, SwaggerSettings swaggerSettings)
        {
            app.UseSwagger(c =>
            {
                c.PreSerializeFilters.Add((swaggerOptions, request) =>
                {
                    swaggerOptions.Host = swaggerSettings.BaseUrl;
                    swaggerOptions.Schemes = new string[] { swaggerSettings.Scheme };
                });
            });

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", SWAGGER_DOC_NAME);
            });

            //if (!env.IsDevelopment())
            //{
            //    app.UseHsts();
            //}

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
