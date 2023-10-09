using dotnet_codesee_demo.Components;
using Xunit;

namespace dotnet_codesee_demo.Tests
{
    public class GetWeatherForecastByIdTests
    {
        [Fact]
        public void HappyPath()
        {
            var getWeatherForecast = new GetWeatherForecast();
            var getById = new GetWeatherForecastById(getWeatherForecast);

            var response = getById.Execute(new GetWeatherForecastById.Request(2));

            Assert.NotNull(response);
        }
    }
}
