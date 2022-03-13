using EGrowFrontendMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace EGrowFrontendMVC.Controllers
{
    public class RastlineController : Controller
    {
        // GET: RastlineController
        public async Task<ActionResult> IndexAsync()
        {
            Plant[] plants = await GetAllPlants();
            List<SensorData> sensorData = new List<SensorData>();
            foreach (Plant plant in plants)
            {
                var sd = await GetSensorData(plant.sensorDataId);
                sensorData.Add(sd);
            }
            ViewData["plants"] = plants;
            ViewData["sensorData"] = sensorData;
            return View();
        }

        // GET: RastlineController/Podrobnosti/5
        public async Task<ActionResult> PodrobnostiAsync(int id)
        {
            Plant plant = await GetPlant(id);
            ViewData["plant"] = plant;
            SensorData sensorData = await GetSensorData(plant.sensorDataId);
            ViewData["sensorData"] = sensorData;
            return View();
        }

        // GET: RastlineController/Create
        public ActionResult Create()
        {
            return View();
        }

        private async Task<Plant[]> GetAllPlants()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(new Uri("https://localhost:44319/api/Plant"));
                string body = await response.Content.ReadAsStringAsync();
                Plant[] plants = JsonSerializer.Deserialize<Plant[]>(body);
                return plants;
            }
        }
        private async Task<Plant> GetPlant(int id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(new Uri($"https://localhost:44319/api/Plant/{id}"));
                string body = await response.Content.ReadAsStringAsync();
                Plant plant = JsonSerializer.Deserialize<Plant>(body);
                return plant;
            }
        }
        private async Task<SensorData> GetSensorData(int id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(new Uri($"https://localhost:44319/api/SensorData/{id}"));
                string body = await response.Content.ReadAsStringAsync();
                SensorData sensorData = JsonSerializer.Deserialize<SensorData>(body);
                return sensorData;
            }
        }



        // POST: RastlineController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }

        // GET: RastlineController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RastlineController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }

        // GET: RastlineController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RastlineController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }
    }
}
