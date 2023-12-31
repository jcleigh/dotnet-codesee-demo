﻿namespace dotnet_codesee_demo.Models
{
    public class WeatherForecast
    {
        public record Forecast(DateTime Date, int TemperatureC, string? Summary)
        {
            public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        }
    }
}
