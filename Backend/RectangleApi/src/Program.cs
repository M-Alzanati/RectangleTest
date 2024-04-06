using Microsoft.AspNetCore.Diagnostics;
using RectangleApi;
using RectangleApi.Models;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .CreateLogger();

builder.Services.AddRectangleService();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();

try
{
    Log.Information("Starting up");

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Rectangle Api"); });
    }


    app.UseRouting();
    app.UseHealthChecks("/healthz");

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller}/{action=Index}/{id?}",
        defaults: new { controller = "" });

    app.UseExceptionHandler(appError =>
    {
        appError.Run(async context =>
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";

            var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
            if(contextFeature != null)
            {
                await context.Response.WriteAsync(new ErrorDetails
                {
                    StatusCode = context.Response.StatusCode,
                    Message = "Internal Server Error.",
                    Detailed = contextFeature.Error.Message
                }.ToString() ?? string.Empty);
            }
        });
    });
    
    app.UseCors("AllowMyOrigin");
    app.Run();
}
catch(Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}