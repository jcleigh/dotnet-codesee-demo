using dotnet_codesee_demo.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<GetWeatherForecast>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/weatherforecast", () =>
{
    var getWeatherForecast = app.Services.GetRequiredService<GetWeatherForecast>();
    return getWeatherForecast.Execute(new GetWeatherForecast.Request());
})
.WithName("GetWeatherForecast");

app.Run();