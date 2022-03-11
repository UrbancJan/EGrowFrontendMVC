namespace EGrowFrontendMVC.Models
{
    public class Plant
    {
        public int plantId { get; set; }
        public string plantName { get; set; }
        public string plantType { get; set; }
        public string instructions { get; set; }
        public int optimalSoilTemperatureCelsius { get; set; }
        public int optimalAmbientTemperatureCelsius { get; set; }
        public int optimalUvIndex { get; set; }
        public int optimalSolarRadiation { get; set; }
        public int optimalLeafWetness { get; set; }
        public int optimalAmbientHumidityPercentage { get; set; }
        public int optimalSoilHumidityPercentage { get; set; }
        public int fullyGrownCm { get; set; }
        public int sensorDataId { get; set; }
    }
}
