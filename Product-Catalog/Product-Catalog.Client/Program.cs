using Blazored.LocalStorage;
using ExternalServices.Helpers;
using ExternalServices.Services.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7079/") });
builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<GetHttpClient>();
builder.Services.AddScoped<LocalStorageService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddScoped<IESAuthenticationService, ESAuthenticationService>();

//var configuration = builder.Configuration;
//var authServiceBaseUrl = configuration["ExternalServices:AuthenticationServiceBaseUrl"];


builder.Services.AddMudServices();

await builder.Build().RunAsync();
