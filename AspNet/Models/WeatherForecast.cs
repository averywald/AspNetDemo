namespace AspNet.Models
{
    public class WeatherForecast
    {
        public int Id;
        
        public string DateFormatted { get; set; }
        public int TemperatureC { get; set; }
        public string Summary { get; set; }

        public int TemperatureF
        {
            get => 32 + (int)(TemperatureC / 0.5556);
        }
    }
}