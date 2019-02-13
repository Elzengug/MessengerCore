using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TokenApp;
using WebApi.BLL.Providers.Contracts;
using WebApi.BLL.Providers.Implementations;
using WebApi.DAL.Data.Contracts;
using WebApi.DAL.Data.Implementations;
using WebApi.DAL.Data.Repositories.Contracts;
using WebApi.DAL.Data.Repositories.Implementations;
using WebApi.DAL.Models.DomainModel.Auth;

namespace WebApi
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
            services.AddRouting();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                   .AddJwtBearer(options =>
                   {
                       options.RequireHttpsMetadata = false;
                       options.TokenValidationParameters = new TokenValidationParameters
                       {
                           ValidateIssuer = true,

                           ValidIssuer = AuthOptions.ISSUER,

                           ValidateAudience = true,

                           ValidAudience = AuthOptions.AUDIENCE,

                           ValidateLifetime = true,

                           IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),

                           ValidateIssuerSigningKey = true,
                       };
                   });

          
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                    });
            });

            services.AddDbContextPool<MessengerDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvcCore()
                .AddApiExplorer()
                .AddJsonFormatters();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserProvider, UserProvider>();
            services.AddTransient<IGroupProvider, GroupProvider>();
            services.AddTransient<IGroupRepository, GroupRepository>();
            services.AddTransient<IClientProvider, ClientProvider>();
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<IClientGroupProvider, ClientGroupProvider>();
            services.AddTransient<IClientGroupRepository, ClientGroupRepository>();
            services.AddTransient<IDbContext, MessengerDbContext>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("AllowAll");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseDefaultFiles();
            app.UseAuthentication();

            app.UseMvc();
            var routeBuilder = new RouteBuilder(app);

            routeBuilder.MapRoute("{controller}/{action}",
                async context => {
                    context.Response.ContentType = "text/html; charset=utf-8";
                });


            routeBuilder.MapRoute("{controller}/{action}/{id}",
                async context => {
                    context.Response.ContentType = "text/html; charset=utf-8";
                });

            app.UseRouter(routeBuilder.Build());

        }
    }
}
