﻿using System.IO;
using System.Reflection;
using CSharpWars.Common.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using CSharpWars.Logic.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace CSharpWars.Web.Api.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureWebApi(this IServiceCollection services)
        {
            services.ConfigureCommon();
            services.ConfigureLogic();
            services.AddMemoryCache();
            services.AddMvc();
            services.AddCors(o => o.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            }));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "CSharpWars", Version = "v1" });
                c.IncludeXmlComments(Path.ChangeExtension(Assembly.GetEntryAssembly().Location, "xml"));
            });
        }
    }
}