using EGrowFrontendMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace EGrowFrontendMVC.Controllers
{
    public class DeviceRegistrationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult DeviceRegistration()
        {
            if (HttpContext.Session.GetString("userID") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult DeviceRegistration(DeviceRegistrationResponse deviceRegistrationResponse)
        {
            if (!ModelState.IsValid)
            {
                return View(deviceRegistrationResponse);
            }

            var userGuid = HttpContext.Session.GetString("userGuid");

            DeviceRegistration deviceRegistration = new DeviceRegistration();
            deviceRegistration.userGuid = userGuid;
            deviceRegistration.deviceGuid = deviceRegistrationResponse.deviceGuid;

            AllDeviceData DeviceRes = new AllDeviceData();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UrlPovezava.urlPovezava + "RegisterDevice");
                var RegisterDevice = client.PostAsJsonAsync<DeviceRegistration>("RegisterDevice", deviceRegistration);
                RegisterDevice.Wait();
                var result = RegisterDevice.Result;
                if (result.IsSuccessStatusCode)
                {
                    var res = result.Content.ReadAsStringAsync().Result;

                    DeviceRes = JsonConvert.DeserializeObject<AllDeviceData>(res);

                    //return RedirectToAction("Index", "Home");
                    ViewBag.Success = "Uspešno dodano!";
                    ModelState.Clear();
                    return View();
                }
            }
            ModelState.AddModelError(string.Empty, "Napaka");
            return View();
        }
    }
}
