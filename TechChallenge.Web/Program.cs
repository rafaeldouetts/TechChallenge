
using Microsoft.EntityFrameworkCore;
using TechChallengeWeb.Data;

var builder = WebApplication.CreateBuilder(args);

//Configurações DB
var connectionString = builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");
builder.Services.AddDbContext<ApplicationContext>(opts => opts.UseSqlServer(connectionString));

//Add Services
builder.Services.AddScoped<IFotosRepository, FotosRepository>();
builder.Services.AddScoped<IFotosRepository, FotosRepository>();
builder.Services.AddScoped<IPublicacaoRepository, PublicacaoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
