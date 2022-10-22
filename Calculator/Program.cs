using Calculator.Utilities.Logger;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Configuration;
using Calculator.Utilities.SQL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton(typeof(DataBaseContext));

//add sql logger
builder.Host.ConfigureLogging((builderContext, logBuilder) =>
{    
    logBuilder.ClearProviders();
    logBuilder.AddConfiguration();
    logBuilder.Services.AddSingleton<ILoggerProvider, LoggerProvider>();
    LoggerProviderOptions.RegisterProviderOptions<LoggerConfig, LoggerProvider>(logBuilder.Services);

});

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
