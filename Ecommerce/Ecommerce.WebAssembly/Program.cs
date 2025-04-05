using Ecommerce.WebAssembly;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.Authorization;
using Ecommerce.WebAssembly.Extensiones;

//LocalStorage
using Blazored.LocalStorage;
//Toast
using Blazored.Toast;

using Ecommerce.WebAssembly.Servicios.Contrato;
using Ecommerce.WebAssembly.Servicios.Implementacion;

using CurrieTechnologies.Razor.SweetAlert2;

//Autentificacion

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//Aqui se pone la URL para consumir nuestros servicios de REST
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7064/api/") });

//Implementaci�n de LocalStorage
builder.Services.AddBlazoredLocalStorage();
//Implementaci�n de Toast
builder.Services.AddBlazoredToast();

//Implementar los servicios
builder.Services.AddScoped<IUsuarioServicio,UsuarioServicio>();
builder.Services.AddScoped<ICategoriaServicio,CategoriaServicio>();
builder.Services.AddScoped<IProductoServicio,ProductoServicio>();
builder.Services.AddScoped<ICarritoServicio,CarritoServicio>();
builder.Services.AddScoped<IVentaServicio,VentaServicio>();
builder.Services.AddScoped<IDashboardServicio,DashboardServicio>();

//Implementaci�n de sweet alert
builder.Services.AddSweetAlert2();

//Autentificacion
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider,AutenticacionExtension>();

await builder.Build().RunAsync();
