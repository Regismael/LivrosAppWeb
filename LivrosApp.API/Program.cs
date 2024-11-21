using ClientesApp.API.Configurations;
using LivrosApp.API.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddRouting(config => { config.LowercaseUrls = true; });

SwaggerConfiguration.AddSwaggerConfiguration(builder.Services);
DependencyInjectionConfiguration.AddDependencyInjection(builder.Services);
CorsConfiguration.AddCorsConfiguration(builder.Services);
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

SwaggerConfiguration.UseSwaggerConfiguration(app);
CorsConfiguration.UseCorsConfiguration(app);
app.UseAuthorization();
app.MapControllers();
app.Run();

public partial class Program { }