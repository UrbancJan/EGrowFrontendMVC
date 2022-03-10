using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EGrowFrontendMVC.Models
{
    public class SensorData
    {
        public int sensorDataId { get; set; }
        public DateTime timestamp { get; set; }
        public double soilTemperatureCelsius { get; set; }
        public double ambientTemperatureCelsius { get; set; }
        public int uvIndex { get; set; }
        public int solarRadiation { get; set; }
        public int leafWetness { get; set; }
        public int ambientHumidityPercentage { get; set; }
        public int soilHumidityPercentage { get; set; }
        public int growthCm { get; set; }
    }
}
