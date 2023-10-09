using dotnet_codesee_demo.Models;

namespace dotnet_codesee_demo.Components
{
    public class GetWeatherForecast
    {
        public class Request { }

        public class Response
        {
            public WeatherForecast.Forecast[] Forecast { get; set; }
        }

        public GetWeatherForecast() { }

        public Response Execute(Request request)
        {
            var summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

            var forecast = Enumerable.Range(1, 5).Select(index =>
                    new WeatherForecast.Forecast
                    (
                        DateTime.Now.AddDays(index),
                        Random.Shared.Next(-20, 55),
                        summaries[Random.Shared.Next(summaries.Length)]
                    ))
                .ToArray();

            return new Response
            {
                Forecast = forecast
            };
        }

        
    }
}
