using dotnet_codesee_demo.Models;

namespace dotnet_codesee_demo.Components
{
    public class GetWeatherForecastById
    {
        private readonly GetWeatherForecast _getWeatherForecast;

        public class Request
        {
            public int Id { get; set; }

            public Request(int id)
            {
                Id = id;
            }
        }

        public class Response
        {
            public WeatherForecast.Forecast Forecast { get; set; }
        }

        public GetWeatherForecastById(GetWeatherForecast getWeatherForecast)
        {
            _getWeatherForecast = getWeatherForecast;
        }

        public Response Execute(Request request)
        {
            var forecasts = _getWeatherForecast.Execute(new GetWeatherForecast.Request());

            var id = request.Id > forecasts.Forecast.Length - 1 
                ? 0
                : request.Id;

            return new Response
            {
                Forecast = forecasts.Forecast[id]
            };
        }
    }
}
