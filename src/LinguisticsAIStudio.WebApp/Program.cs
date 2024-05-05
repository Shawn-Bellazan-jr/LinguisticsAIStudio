using LinguisticsAIStudio.WebApp;
using LinguisticsAIStudio.WebApp.APIs;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Refit;


var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
/*
var _projects = $"{builder.HostEnvironment.BaseAddress}";
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });*/
builder.Services
    .AddRefitClient<IProjectAPI>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri($"{builder.HostEnvironment.BaseAddress}/data"));

JsonConvert.DefaultSettings =
    () => new JsonSerializerSettings()
    {
        ContractResolver = new CamelCasePropertyNamesContractResolver(),
        Converters = { new StringEnumConverter() }
    };
await builder.Build().RunAsync();
