using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using NSE.Identidade.API.Extensions;
using Serilog.Sinks.MSSqlServer;
using Serilog;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using TechChallenge.Identity.Data;

namespace TechChallenge.Identity.Extensions
{
    public static class DependencyInjectionApplication
    {
        public static IServiceCollection AddDIAuthentication(this IServiceCollection services, WebApplicationBuilder? builder)
        {
            //AddIdentity
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationContext>()
                .AddErrorDescriber<IdentityMensagensPortugues>()
                .AddDefaultTokenProviders();

            //AddAuthentication
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            //AddJwtBearer
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidAudience = builder.Configuration["JWT:ValidAudience"],
                    ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
                };
            });


            return services;
        }

        public static IServiceCollection AddDICors(this IServiceCollection services, WebApplicationBuilder? builder)
        {
            //cors
            var politica = "CorsPolicy-public";

            builder.Services.AddCors(option => option.AddPolicy(politica, builder => builder.WithOrigins("http://localhost:4200", "https://localhost")
                 .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials()
                            .Build()));


            return services;
        }

        public static IServiceCollection AddDILogs(this IServiceCollection services, WebApplicationBuilder? builder)
        {
            //Log configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json")
                        .Build();

            var connectionStringLog = builder.Configuration.GetConnectionString("Log_SQL_CONNECTIONSTRING");

            var option = new ColumnOptions
            {
                AdditionalColumns = new Collection<SqlColumn>
    {
        new SqlColumn {ColumnName = "Action"}
    }
            };

            var sinkOpts = new MSSqlServerSinkOptions();

            Log.Logger = new LoggerConfiguration()
                        .ReadFrom.Configuration(configuration)
                        .CreateLogger();

            Serilog.Debugging.SelfLog.Enable(msg =>
            {
                Debug.Print(msg);
                Debugger.Break();
            });
            builder.Host.UseSerilog();

            return services;
        }

    }
}
