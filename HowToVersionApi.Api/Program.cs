using HowToVersionApi.Api;
using HowToVersionApi.Api.OpenWeather;
using HowToVersionApi.Api.OpenWeather.Services;
using HowToVersionApi.Contracts.V2023_11_20;
using HowToVersionApi.Contracts.V2023_11_21;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApiVersioning(o =>
{
    o.ReportApiVersions = true;
    o.ApiVersionReader = new QueryStringApiVersionReader("api-version");
    o.AssumeDefaultVersionWhenUnspecified = false;
})
.AddMvc()
.AddApiExplorer(v =>
{
    v.GroupNameFormat = "'V'yyyy-MM-dd";
    v.SubstituteApiVersionInUrl = true;
});

builder.Configuration.AddUserSecrets<Program>();
builder.Services.AddHttpClient();

builder.Services.AddVersion<V20231120>();
builder.Services.AddVersion<V20231121>();

builder.Services.AddSingleton<IOpenWeatherService, OpenWeatherService>();
builder.Services.Configure<OpenWeatherApiConfiguration>(builder.Configuration.GetSection(nameof(OpenWeatherApiConfiguration)));


builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(options => options.RegisterServicesFromAssemblyContaining<Program>());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        foreach (var description in app.DescribeApiVersions())
        {
            var url = $"/swagger/{description.GroupName}/swagger.json";
            var name = description.GroupName.ToUpperInvariant();
            options.SwaggerEndpoint(url, name);
        }
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

namespace HowToVersionApi.Api
{
    public partial class Program { }
}