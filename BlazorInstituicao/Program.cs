// Program.cs

using BlazorInstituicao;
using BlazorInstituicao.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

// Registrar o servi�o BlazorInstituicaoService
builder.Services.AddScoped<BlazorInstituicaoService>();

await builder.Build().RunAsync();
