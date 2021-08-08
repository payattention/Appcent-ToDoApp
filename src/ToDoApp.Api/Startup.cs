using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Couchbase.Extensions.DependencyInjection;
using Couchbase;
using Couchbase.Configuration.Client;
using System;
using System.Collections.Generic;
using Couchbase.Authentication;
using System.Reflection;
using MediatR;
using ToDoApp.ApplicationService.Communicator.ToDo;
using ToDoApp.Repository;
using ToDoApp.ApiContract.Contracts;

namespace ToDoApp.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IConfiguration Configuration { get; }

        public Startup(Microsoft.Extensions.Hosting.IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddHttpClient();
            services.AddOptions();
            services.Configure<CouchbaseSettingsModel>(Configuration.GetSection("Couchbase"));
            services.AddCouchbase(Configuration.GetSection("Couchbase"));
            //ClusterHelper.Initialize(new ClientConfiguration
            //{
            //     Servers = new List<Uri> { new Uri ("couchbase://localhost")}
            //}, new PasswordAuthenticator("Karalar","19190719")); 

            //services.AddCouchbase(client =>
            //{
            //    client.Servers = new List<Uri> { new Uri("http://localhost:8091") };
            //    client.UseSsl = false;
            //});

            services.AddSwaggerGen();

            var assembly = AppDomain.CurrentDomain.Load("ToDoApp.ApplicationService");
            services.AddMediatR(assembly);

            services.AddScoped<IToDoCouchbaseInstruction, ToDoCouchbaseInstruction>();
            services.AddScoped<IToDoCommunicator, ToDoCommunicator>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime lifeTime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ToDoApp V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            lifeTime.ApplicationStopped.Register(() => app.ApplicationServices.GetRequiredService<ICouchbaseLifetimeService>().Close());
        }
    }
}
