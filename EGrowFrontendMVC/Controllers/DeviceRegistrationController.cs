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

       // [HttpPost]
        //public ActionResult DeviceRegistration(DeviceRegistration device)
      /*  public ActionResult DeviceRegistration()
        {
            var userGuid = this.Request.Cookies["username"];
            Console.Write(userGuid);
            return View();
            /*
            AllDeviceData DeviceRes = new AllDeviceData();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44319/api/RegisterDevice");
                var RegisterDevice = client.PostAsJsonAsync<DeviceRegistration>("RegisterDevice", device);
                RegisterDevice.Wait();
                var result = RegisterDevice.Result;
                if (result.IsSuccessStatusCode)
                {
                    var res = result.Content.ReadAsStringAsync().Result;

                    DeviceRes = JsonConvert.DeserializeObject<AllDeviceData>(res);

                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError(string.Empty, "Napaka");
            return View();*/
       // }
    }
}
