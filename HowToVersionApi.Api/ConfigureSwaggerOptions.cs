namespace HowToVersionApi.Api;

public class ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) : IConfigureOptions<SwaggerGenOptions>
{
    public void Configure(SwaggerGenOptions options)
    {
        foreach (var description in provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(
                description.GroupName,
                new OpenApiInfo()
                {
                    Title = $"Super Awesome Weather API {description.ApiVersion}",
                    Version = description.ApiVersion.ToString(),
                });
        }
    }
}