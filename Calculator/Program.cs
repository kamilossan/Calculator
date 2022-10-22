using Calculator.Utilities.Logger;
using Microsoft.Extensions.Logging.Configuration;
using Calculator.Utilities.SQL;
using Calculator.Services;
using Calculator.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config =>
{
    config.AddSecurityDefinition("basic", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        BearerFormat = "Base64",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Scheme = "basic"
    });
    config.OperationFilter<AuthHeaderFilter>();
});
builder.Services.AddSingleton(typeof(DataBaseContext));
builder.Services.AddSingleton<IBasicAuthorizationService, BasicAuthorizationService>();
builder.Services.AddSingleton<ICalculatorService, CalculatorService>();

//add sql logger
builder.Host.ConfigureLogging((builderContext, logBuilder) =>
{
    logBuilder.ClearProviders();
    logBuilder.AddConfiguration();
    logBuilder.Services.AddSingleton<ILoggerProvider, LoggerProvider>();
    LoggerProviderOptions.RegisterProviderOptions<LoggerConfig, LoggerProvider>(logBuilder.Services);

});

//adds local setting to configure test user for basic auth
builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);

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
