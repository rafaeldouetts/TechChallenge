using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using TechChallangeApi.Controllers;
using TechChallangeApi.Data;
using TechChallenge.Api.Factory;
using TechChallenge.Api.Models;
using TechChallenge.Api.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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

Serilog.Log.Logger = new LoggerConfiguration()
			.ReadFrom.Configuration(configuration)
			.CreateLogger();

Serilog.Debugging.SelfLog.Enable(msg =>
{
	Debug.Print(msg);
	Debugger.Break();
});

builder.Host.UseSerilog();


//Configurações DB
var connectionString = builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");
builder.Services.AddDbContext<ApplicationContext>(opts => opts.UseSqlServer(connectionString));

//Add Services
builder.Services.AddScoped<IFotosRepository, FotosRepository>();
builder.Services.AddScoped<IFotosRepository, FotosRepository>();
builder.Services.AddScoped<IPublicacaoRepository, PublicacaoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

//Add Facotry
builder.Services.AddScoped<ILogFactory, LogFactory>();


// ?????
// É a melhor forma de configurar o serviço de HTTPRTEQUEST???
builder.Services.AddHttpClient<FotoController>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//cors
var politica = "CorsPolicy-public";

builder.Services.AddCors(option => option.AddPolicy(politica, builder => builder.WithOrigins("http://localhost:4200", "https://localhost")
	 .AllowAnyMethod()
				.AllowAnyHeader()
				.AllowCredentials()
				.Build()));

//authentication
var key = Encoding.ASCII.GetBytes("1f1ce09a-0b07-4fd8-889e-e3e18442b081");

builder.Services.AddAuthentication(x =>
{
	x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
	x.RequireHttpsMetadata = false;
	x.SaveToken = true;
	x.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuerSigningKey = true,
		IssuerSigningKey = new SymmetricSecurityKey(key),
		ValidateIssuer = false,
		ValidateAudience = false
	};
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//cors
app.UseCors("CorsPolicy-public");
app.UseAuthorization();

app.MapControllers();

app.Run();
