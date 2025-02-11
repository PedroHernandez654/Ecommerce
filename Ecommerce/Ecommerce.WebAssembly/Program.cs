using Ecommerce.WebAssembly;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

//LocalStorage
using Blazored.LocalStorage;
//Toast
using Blazored.Toast;

using Ecommerce.WebAssembly.Servicios.Contrato;
using Ecommerce.WebAssembly.Servicios.Implementacion;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//Aqui se pone la URL para consumir nuestros servicios de REST
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7064/api/") });

//Implementación de LocalStorage
builder.Services.AddBlazoredLocalStorage();
//Implementación de Toast
builder.Services.AddBlazoredToast();

//Implementar los servicios
builder.Services.AddScoped<IUsuarioServicio,UsuarioServicio>();
builder.Services.AddScoped<ICategoriaServicio,CategoriaServicio>();
builder.Services.AddScoped<IProductoServicio,ProductoServicio>();
builder.Services.AddScoped<ICarritoServicio,CarritoServicio>();
builder.Services.AddScoped<IVentaServicio,VentaServicio>();
builder.Services.AddScoped<IDashboardServicio,DashboardServicio>();


await builder.Build().RunAsync();
