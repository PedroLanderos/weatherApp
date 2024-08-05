namespace CloudWeather.Precipitation.DataAccess
{
    public class Precipitation
    {
        public Guid ID { get; set; }
        public DateTime CreatedOn { get; set; }
        public decimal AomuntInches { get; set; }
        public string WeatherTime { get; set; }
        public string ZipCode { get; set; }
    }
}
