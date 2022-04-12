using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using zyberfox.challenge.data.Cache;
using zyberfox.challenge.data.Entities;
using System;
using User.Core.Repositories.Base;
using User.Infrastructure.Repositories.Base;
using User.Application.Handlers;
using System.Reflection;
using MediatR;
using User.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using User.Infrastructure.Repositories;
using AutoMapper;

namespace zyberfox.challenge.api
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
            services.AddControllers();
            services.AddMvc();

            services.AddDbContext<UserContext>(m => m.UseSqlServer(Configuration.GetConnectionString("userdb")), ServiceLifetime.Singleton);
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "User.API",
                    Version = "v1"
                });
            });

            services.AddAutoMapper(typeof(Startup));
            services.AddMediatR(typeof(CreateUserHandler).GetTypeInfo().Assembly);
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<User.Core.Repositories.IUserRepository, UserRepository>();
            services.AddSingleton<ISimpleObjectCache<Guid, User.Core.Entities.User>, SimpleObjectCache<Guid, User.Core.Entities.User>>();        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
