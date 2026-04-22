var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();


// 1. Singleton: Solo existe UNA instancia del Repositorio en toda la aplicación (Ideal para guardar estado/listas)
builder.Services.AddSingleton<Backend.Repositories.RepositorioTienda>();

// 2. Scoped: Se crea una nueva instancia del Servicio por cada petición HTTP que llega (Buena práctica para lógica)
builder.Services.AddScoped<Backend.Services.ConfigService>();
builder.Services.AddScoped<Backend.Services.TransaccionService>();
builder.Services.AddScoped<Backend.Services.ConsultaService>();

// 3. Configuración de CORS (Para permitir las peticiones desde REACT)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()  // Permite cualquier origen (útil en desarrollo)
              .AllowAnyMethod()  // GET, POST, PUT, DELETE, etc.
              .AllowAnyHeader(); // Content-Type, Authorization, etc.
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Habilitamos CORS con la política definida
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
