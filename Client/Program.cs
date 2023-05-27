using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using GestorDeGastos.Client;
using GestorDeGastos.Client.Managers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IUsuarioManager,UsuarioManager>();
builder.Services.AddScoped<IMercanciaManager,MercanciaManager>();
builder.Services.AddScoped<IGastosMercanciaManager,GastosMercanciaManager>();

await builder.Build().RunAsync();
