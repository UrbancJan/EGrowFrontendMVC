using System;

namespace EGrowFrontendMVC.Models
{
    public class Device
    {
        public int deviceId { get; set; }
        public string deviceGuid { get; set; }
        public int waterTankLevel { get; set; }
        public int fertilizerLevel { get; set; }
        public bool hasError { get; set; }
        public string errorMessage { get; set; }
        public DateTime deviceManufactured { get; set; }
        public DateTime deviceRegisteredToUser { get; set; }
        public SensorData[] sensorMeasurements { get; set; }
        


    }
}
