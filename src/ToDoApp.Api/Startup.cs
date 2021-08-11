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
using ToDoApp.ApplicationService.Communicator.SectionTodo;
using ToDoApp.Domain.BaseModels;
using ToDoApp.ApplicationService.Communicator.UserToDo;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

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
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettingsToken>(appSettingsSection);

            services.AddCouchbase(Configuration.GetSection("Couchbase"));

            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description =
            "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement(){
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
            });

            var assembly = AppDomain.CurrentDomain.Load("ToDoApp.ApplicationService");
            services.AddMediatR(assembly);

            services.AddScoped<IToDoCouchbaseRepository, ToDoCouchbaseRepository>();
            services.AddScoped<ISectionToDoCouchbaseRepository, SectionToDoCouchbaseRepository>();
            services.AddScoped<IUserCouchbaseRepository, UserCouchbaseRepository>();

            services.AddScoped<IToDoCommunicator, ToDoCommunicator>();
            services.AddScoped<ISectionToDoCommunicator, SectionToDoCommunicator>();
            services.AddScoped<IUserToDoCommunicator, UserToDoCommunicator>();

            services.AddAuthentication(SchemeOptions => 
            {
                SchemeOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                SchemeOptions.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                SchemeOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            
            }).AddJwtBearer(
            options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Secret").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            }
      );

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
            app.UseAuthentication();
            app.UseAuthorization();
            

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
