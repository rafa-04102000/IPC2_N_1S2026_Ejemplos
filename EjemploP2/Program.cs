using EjemploP2.EsctructuraDeDatos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Agrego mi clase, con Singleton, que sera para tener una unica instancia y poder realizar la inyeccion de dependencias,
// es decir, que cada vez que se necesite esta clase, se use la misma instancia,
// lo cual es util para mantener el estado de los datos en memoria durante toda la vida de la aplicación.
builder.Services.AddSingleton<Repositorio>();

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
