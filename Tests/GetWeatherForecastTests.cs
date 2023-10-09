using dotnet_codesee_demo.Components;
using Xunit;

namespace dotnet_codesee_demo
{
    public class GetWeatherForecastTests
    {
        [Fact]
        public void HappyPath()
        {
            var getWeatherForecast = new GetWeatherForecast();

            var response = getWeatherForecast.Execute(new GetWeatherForecast.Request());

            Assert.Equal(5, response.Forecast.Length);
        }
    }
}