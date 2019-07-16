using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts;
using Application.Services;
using Autofac.Extensions.DependencyInjection;
using Domain.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Autofac;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Repositories;

namespace ApiCubeSummation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private static Autofac.IContainer ApplicationContainer { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", p => p.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().WithExposedHeaders());
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            CreateDependencyInjection(services);
            return new AutofacServiceProvider(ApplicationContainer);

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
                app.UseHsts();
            }

            app.UseCors("AllowAll");

            app.UseHttpsRedirection();
            app.UseMvc();

        }

        public void CreateDependencyInjection(IServiceCollection services)
        {
            // create a Autofac container builder
            ContainerBuilder builder = new ContainerBuilder();
            // read service collection to Autofac
            builder.Populate(services);
            // use and configure Autofac+

            //Services
            builder.RegisterType<CubeSummationService>().As<ICubeSummationService>();

            //Repositories
            builder.RegisterType<TextDataSourceRepository>().As<ITextDataSourceRepository>();

            // build the Autofac container
            ApplicationContainer = builder.Build();
        }
    }
}
