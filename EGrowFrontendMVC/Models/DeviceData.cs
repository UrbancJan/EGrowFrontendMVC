using System;

namespace EGrowFrontendMVC.Models
{
    public class DeviceData
    {
        public int sensorDataId { get; set; }
        public DateTime timestamp { get; set; }
        public double soilTemperatureCelsius { get; set; }
        public double ambientTemperatureCelsius { get; set; }
        public double uvIndex { get; set; }
        public double solarRadiation { get; set; }
        public double leafWetness { get; set; }
        public double ambientHumidityPercentage { get; set; }
        public double soilHumidityPercentage { get; set; }
        public double growthCm { get; set; }
        public int deviceId { get; set; }
        public Plant plant { get; set; }

    }
}
