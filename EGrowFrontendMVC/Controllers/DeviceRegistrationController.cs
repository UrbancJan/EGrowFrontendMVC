using EGrowFrontendMVC.Models;
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
            return View();
        }

        [HttpPost]
        public ActionResult DeviceRegistration(int userid)
        {
            var userGuid = this.Request.Cookies["userGuid"];
            var deviceGuid = Guid.NewGuid();

            DeviceRegistration deviceRegistration = new DeviceRegistration();
            deviceRegistration.userGuid = userGuid;
            deviceRegistration.deviceGuid = deviceGuid.ToString();
            //deviceRegistration.deviceGuid = "74bf9d34-1c09-45eb-80b9-f16b4b11180c";

            AllDeviceData DeviceRes = new AllDeviceData();
            using (var client = new HttpClient())
            {
                //client.BaseAddress = new Uri("https://localhost:44319/api/RegisterDevice");
                client.BaseAddress = new Uri(UrlPovezava.urlPovezava + "RegisterDevice");
                var RegisterDevice = client.PostAsJsonAsync<DeviceRegistration>("RegisterDevice", deviceRegistration);
                RegisterDevice.Wait();
                var result = RegisterDevice.Result;
                if (result.IsSuccessStatusCode)
                {
                    var res = result.Content.ReadAsStringAsync().Result;

                    DeviceRes = JsonConvert.DeserializeObject<AllDeviceData>(res);

                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
    }
}
