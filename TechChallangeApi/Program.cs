using Microsoft.EntityFrameworkCore;
using TechChallangeApi.Controllers;
using TechChallangeApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Configurações DB
var connectionString = builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");
builder.Services.AddDbContext<ApplicationContext>(opts => opts.UseSqlServer(connectionString));

//Add Services
builder.Services.AddScoped<IFotosRepository, FotosRepository>();
builder.Services.AddScoped<IFotosRepository, FotosRepository>();
builder.Services.AddScoped<IPublicacaoRepository, PublicacaoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

// ?????
// É a melhor forma de configurar o serviço de HTTPRTEQUEST???
builder.Services.AddHttpClient<FotoController>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
