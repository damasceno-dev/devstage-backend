namespace DevStage.API;

public static class ApiDependencyInjection
{
    public static void AddApi(this IServiceCollection services, IConfiguration configuration)
    {
        AddCors(services);
    }

    private static void AddCors(IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });

    }
}