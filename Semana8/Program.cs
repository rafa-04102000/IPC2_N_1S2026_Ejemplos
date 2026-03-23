using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Semana8.Data;
using Semana8.EstructuraDeDatos;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Es el contexto para enlazar nuestros modelos con una base de datos, usa Entity Framework Core con ORM
//builder.Services.AddDbContext<Semana8Context>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("Semana8Context") ?? throw new InvalidOperationException("Connection string 'Semana8Context' not found.")));

// Esto es para reemplazar lo de arriba, y usar una base de datos en memoria, para no tener que configurar SQL Server
//builder.Services.AddDbContext<Semana8Context>(options =>
//    options.UseInMemoryDatabase("BaseDeDatosPeliculasTemporal"));

// Como uso listas enlazadas para almacenar las peliculas, no necesito configurar una base de datos,
// por lo que no es necesario agregar el servicio de DbContext
builder.Services.AddSingleton<RepositorioPeliculas>();
// aca le indico que se instancie una sola vez y cuando pregunten por ella se les entregue la misma instancia,
// esto es porque quiero que la lista enlazada se mantenga durante toda la ejecucion de la aplicacion,
// y no se pierda cada vez que se haga una peticion, si usara AddTransient se crearia una nueva instancia cada vez que se haga una peticion,
// y se perderia la informacion de las peliculas almacenadas en la lista enlazada

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
