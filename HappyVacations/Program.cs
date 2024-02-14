using HappyVacations;
using HappyVacations.Repos;
using HappyVacations.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.FluentUI.AspNetCore.Components;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IRepository, FirestoreReporistory>();
//builder.Services.AddScoped<IRepository, InMemoryRepository>();
builder.Services.AddScoped<VacationCalculatorService>();
builder.Services.AddSingleton<AppTheme>();

builder.Services.AddFluentUIComponents();

await builder.Build().RunAsync();
