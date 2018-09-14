using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TheBindery.Domain.Factories;
using TheBindery.Domain.Repositories;
using TheBindery.Domain.Services;
using TheBindery.Infrastructure.EFCore.SqlServer;
using TheBindery.Infrastructure.EFCore.SqlServer.Repositories;

namespace TheBindery
{
    public class Startup
    {

        private readonly ILogger<Startup> _logger;

        public Startup(ILogger<Startup> logger,IConfiguration configuration)
        {
            _logger = logger;
            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            // EF Core SQL Server:

            services.AddDbContext<TheBinderyDataContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("TheBindery"));
            });


            // Factories:

            services.AddTransient<ITheBinderyContentFactory, TheBinderyContentFactory>();

            // Services:
            services.AddTransient<IGalleryImageService, GalleryImageService>();
            services.AddTransient<IEventService, EventService>();
            services.AddTransient<INewsService, NewsService>();

            // Repositories:
            services.AddTransient<IRepositoryContext, RepositoryContext>();
            services.AddTransient<ITheBinderyContentRepository, TheBinderyContentRepository>();


            // AutoMapper:

            services.AddAutoMapper();

            // ASP.NET Core:

            services.AddCors();

            services.AddMvc()
                    .AddJsonOptions(options =>
                    {
                        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // ASP.NET Core
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder =>
            {
                builder.AllowAnyHeader()
                       .AllowAnyMethod()
                       .AllowAnyOrigin()
                       .AllowCredentials();
            });

            app.UseStaticFiles();

            app.UseMvcWithDefaultRoute();
        }
    }
}
