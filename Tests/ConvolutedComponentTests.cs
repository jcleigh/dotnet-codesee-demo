using dotnet_codesee_demo.Components;
using Xunit;

namespace dotnet_codesee_demo.Tests
{
    public class ConvolutedComponentTests
    {
        [Fact]
        public void HappyPath()
        {
            var getWeatherForecast = new GetWeatherForecast();
            var getById = new GetWeatherForecastById(getWeatherForecast);
            var getThing = new GetThing();
            var convoluted = new ConvolutedComponent(getWeatherForecast, getById, getThing);

            var response = convoluted.Execute(new ConvolutedComponent.Request(false, null));

            Assert.NotNull(response);
        }

        [Fact]
        public void HappyPath2()
        {
            var getWeatherForecast = new GetWeatherForecast();
            var getById = new GetWeatherForecastById(getWeatherForecast);
            var getThing = new GetThing();
            var convoluted = new ConvolutedComponent(getWeatherForecast, getById, getThing);

            var response = convoluted.Execute(new ConvolutedComponent.Request(true, null));

            Assert.NotNull(response);
            Assert.NotEmpty(response.Forecasts);
        }

        [Fact]
        public void HappyPath3()
        {
            var getWeatherForecast = new GetWeatherForecast();
            var getById = new GetWeatherForecastById(getWeatherForecast);
            var getThing = new GetThing();
            var convoluted = new ConvolutedComponent(getWeatherForecast, getById, getThing);

            var response = convoluted.Execute(new ConvolutedComponent.Request(true, 3));

            Assert.NotNull(response);
            Assert.NotEmpty(response.Forecasts);
            Assert.NotNull(response.Forecast);
        }

        [Fact]
        public void HappyPath4()
        {
            var getWeatherForecast = new GetWeatherForecast();
            var getById = new GetWeatherForecastById(getWeatherForecast);
            var getThing = new GetThing();
            var convoluted = new ConvolutedComponent(getWeatherForecast, getById, getThing);

            var response = convoluted.Execute(new ConvolutedComponent.Request(false, 4));

            Assert.NotNull(response);
            Assert.NotNull(response.Forecast);
        }
    }
}
