﻿using System;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pki.eBusiness.ErpApi.Entities.Settings;
using Pki.eBusiness.ErpApi.Web.Attributes;
using Pki.eBusiness.ErpApi.Web.Filters;
using Swashbuckle.AspNetCore.Swagger;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using Microsoft.Extensions.Logging;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using Pki.eBusiness.ErpApi.Contract.DAL;
using Pki.eBusiness.ErpApi.DataAccess;
using Serilog;

namespace Pki.eBusiness.ErpApi.Web
{
    public class Startup
    {
        private IConfiguration _config { get; }

        private const string SWAGGER_DOC_NAME = "Erp API";
        public Startup(IConfiguration configuration)
        {
            _config = configuration;
            initializeLogger();
        }

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
                config.Filters.Add(new IPLoggingFilter(Log.Logger));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1).AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.Converters.Add(new StringEnumConverter());
            }); 

            services.Scan(scan =>
            {
                var one = scan.FromApplicationDependencies(a => 
                    a.FullName.StartsWith("Pki.eBusiness.ErpApi", StringComparison.CurrentCulture));
                var two = one.AddClasses(c => c.Where(t => t.Name != "BackupRepository"));
                var three = two.AsMatchingInterface();
            });

            var swaggerSettings = new SwaggerSettings();
            _config.Bind("SwaggerSettings", swaggerSettings);
            services.AddSingleton(swaggerSettings);
            var erpRestSettings = new ERPRestSettings();
            _config.Bind("ErpRestSettings", erpRestSettings);
            services.AddSingleton(erpRestSettings);
            var backupDbSettings = new BackupDbSettings();
            _config.Bind("BackupDbSettings", backupDbSettings);
            services.AddSingleton(backupDbSettings);
            services.AddSingleton<IBackupRepository, BackupRepository>();
            ILoggerFactory loggerFactory = new LoggerFactory();
            loggerFactory.AddSerilog();
            services.AddSingleton(loggerFactory);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = SWAGGER_DOC_NAME, Version = "v1" });
            });
            ConventionRegistry.Register("IgnoreIfDefault", new ConventionPack { new IgnoreIfNullConvention(true) },
                t => true);
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

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private void initializeLogger()
        {
            var date = DateTime.Now.ToString(_config.GetValue<string>("LoggerConfiguration:logFileDateFormat"));
            var file = _config.GetValue<string>("LoggerConfiguration:logFileTemplate");
            var logFile = file.Replace("{date}", date.ToString());
            var logDirectory = _config.GetValue<string>("LoggerConfiguration:logFileDirectory");
            Log.Logger = new Serilog.LoggerConfiguration().WriteTo.File($"{logDirectory}{logFile}").CreateLogger();
        }

    }
}
