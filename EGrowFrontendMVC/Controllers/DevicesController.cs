using EGrowFrontendMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace EGrowFrontendMVC.Controllers
{
    public class DevicesController : Controller
    {
        private string baseUrl = "https://localhost:44319";
        // GET: DeviceController
        public async Task<ActionResult> IndexAsync()
        {
            string userGuid = getUserGuid();
            Device[] devices = await getDevices(userGuid);
            ViewData["devices"] = devices;
            return View();
        }

        private async Task<Device[]> getDevices(string userGuid)
        {
            using (var client = new HttpClient())
            {
                string uri = $"{baseUrl}/api/LookupDevices?userGuid={userGuid}";
                HttpResponseMessage response = await client.GetAsync(new Uri(uri));
                string body = await response.Content.ReadAsStringAsync();
                Device[] devices = JsonSerializer.Deserialize<Device[]>(body);
                return devices;
            }
        }
        
        private async Task<DeviceData> getDeviceData(string userGuid, string deviceGuid)
        {

            using (var client = new HttpClient())
            {
                string uri = $"{baseUrl}/api/LatestDeviceData?deviceGuid={deviceGuid}&userGuid={userGuid}";
                HttpResponseMessage response = await client.GetAsync(new Uri(uri));
                string body = await response.Content.ReadAsStringAsync();
                DeviceData deviceData = JsonSerializer.Deserialize<DeviceData>(body);
                return deviceData;
            }
        }

        private string getUserGuid()
        {
            return Request.Cookies["userGuid"];
        }

        // GET: DeviceController/Details/5
        public async Task<ActionResult> DetailsAsync(string id)
        {
            string uid = getUserGuid();
            DeviceData deviceData = await getDeviceData(uid, id);

            ViewData["deviceData"] = deviceData;
            return View();
        }

        // GET: DeviceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeviceController/Create
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

        // GET: DeviceController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DeviceController/Edit/5
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

        // GET: DeviceController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DeviceController/Delete/5
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
