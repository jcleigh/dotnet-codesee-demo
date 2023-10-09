using dotnet_codesee_demo.Models;

namespace dotnet_codesee_demo.Components
{
    public class ConvolutedComponent
    {
        private readonly GetWeatherForecast _getWeatherForecast;
        private readonly GetWeatherForecastById _getWeatherForecastById;
        private readonly GetThing _getThing;

        public class Request
        {
            public bool GetWeatherForecast { get; set; }
            public int? Id { get; set; }

            public Request(bool getWeatherForecast, int? id)
            {
                GetWeatherForecast = getWeatherForecast;
                Id = id;
            }
        }

        public class Response
        {
            public WeatherForecast.Forecast[]? Forecasts { get; set; }
            public WeatherForecast.Forecast? Forecast { get; set; }
            public object? Thing { get; set; }
        }

        public ConvolutedComponent(GetWeatherForecast getWeatherForecast, GetWeatherForecastById getWeatherForecastById, GetThing getThing)
        {
            _getWeatherForecast = getWeatherForecast;
            _getWeatherForecastById = getWeatherForecastById;
            _getThing = getThing;
        }

        public Response Execute(Request request)
        {
            var response = new Response();

            if (request.GetWeatherForecast)
            {
                var forecasts = _getWeatherForecast.Execute(new GetWeatherForecast.Request());
                response.Forecasts = forecasts.Forecast;
            }

            if (request.Id.HasValue)
            {
                var forecast = _getWeatherForecastById.Execute(new GetWeatherForecastById.Request(request.Id.Value));
                response.Forecast = forecast.Forecast;
            }

            response.Thing = _getThing.Execute(new GetThing.Request()).Thing;

            return response;
        }
    }
}
