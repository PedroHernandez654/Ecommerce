using Ecommerce.Repositorio.DBContext;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Repositorio.Contrato;
using Ecommerce.Repositorio.Implementacion;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Implementación de dependencias de conexión a BD
builder.Services.AddDbContext<DbecommerceContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSQL"));
});

//Servicios
builder.Services.AddTransient(typeof(IGenericoRepositorio<>), typeof(GenericoRepositorio<>));//No se sabe que modelos se van a trabajar
builder.Services.AddScoped<IVentaRepositorio, VentaRepositorio>();//Aqui si sabemos que modelos se van a trabajar

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
