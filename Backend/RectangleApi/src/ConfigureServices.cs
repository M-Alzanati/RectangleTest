using RectangleApi.Services;

namespace RectangleApi;

public static class ConfigureServices
{
    public static IServiceCollection AddRectangleService(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSingleton<RectangleService>();
        
        services.AddCors(options =>
        {
            options.AddPolicy("AllowMyOrigin",
                builder => builder.WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });
        
        return services;
    }
}