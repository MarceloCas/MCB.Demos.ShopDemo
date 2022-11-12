using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using MCB.Demos.ShopDemo.Microservices.Customer.Services.WebApi.Services;
using MCB.Demos.ShopDemo.Microservices.Customer.Services.WebApi.HealthCheck;
using MCB.Core.Infra.CrossCutting.DependencyInjection;
using MCB.Demos.ShopDemo.Microservices.Customer.Services.WebApi.Middlewares;
using MCB.Demos.ShopDemo.Microservices.Customer.Services.WebApi.Adapters;
using MCB.Demos.ShopDemo.Microservices.Customer.Infra.CrossCutting.Settings;

var builder = WebApplication.CreateBuilder(args);

#region Config
var appSettings = builder.Configuration.Get<AppSettings>(); 
#endregion

#region Configure Services
builder.Services.AddMcbDependencyInjection(dependencyInjectionContainer =>
    MCB.Demos.ShopDemo.Microservices.Customer.Services.WebApi.DependencyInjection.Bootstrapper.ConfigureDependencyInjection(
        dependencyInjectionContainer,
        adapterMapAction: typeAdapterConfig => AdapterConfig.Configure(typeAdapterConfig),
        appSettings
    )
);

builder.Services.AddGrpc();
builder.Services.AddControllers();
builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(majorVersion: 1, minorVersion: 0);
    options.ReportApiVersions = true;
});
builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "MCB.Demos.ShopDemo.Microservices.Customer",
        Description = "API Microservices Customer",
        Contact = new OpenApiContact() { 
            Name = "Marcelo Castelo Branco", 
            Email = "marcelo.castelo@outlook.com", 
            Url = new Uri("https://www.linkedin.com/in/marcelocastelobranco/")
        }
    });
});
builder.Services.AddHealthChecks().AddCheck<DefaultHealthCheck>("Default");

#endregion

#region Configure Pipeline

var app = builder.Build();

app.UseMcbDependencyInjection();
app.MapGrpcService<GreeterService>();
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
});
app.UseHttpsRedirection();
app.MapControllers();
app.MapHealthChecks("/health"); 

#endregion

app.Run();
