using dotnet_codesee_demo.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<GetWeatherForecast>();
builder.Services.AddTransient<GetWeatherForecastById>();
builder.Services.AddTransient<ConvolutedComponent>();
builder.Services.AddTransient<GetThing>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/weatherforecast", (GetWeatherForecast getWeatherForecast) =>
    {
        var response = getWeatherForecast.Execute(new GetWeatherForecast.Request());
        return response;
    })
.WithName("GetWeatherForecast");

app.MapGet("/weatherforecast/{id}", (GetWeatherForecastById getWeatherForecastById, int id) =>
    {
        var response = getWeatherForecastById.Execute(new GetWeatherForecastById.Request(id));
        return response;
    })
.WithName("GetWeatherForecastById");

app.MapGet("/convoluted", (ConvolutedComponent convoluted, bool? getWeatherForecast, int? id) =>
    {
        var getForecast = getWeatherForecast ?? false;
        var response = convoluted.Execute(new ConvolutedComponent.Request(getForecast, id));
        return response;
    })
.WithName("Convoluted");

app.Run();