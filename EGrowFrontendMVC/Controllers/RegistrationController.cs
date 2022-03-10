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
    public class RegistrationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(UserResponse user)
        {
            User userRes = new User();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44319/api/Register");
                var login = client.PostAsJsonAsync<UserResponse>("Register", user);
                login.Wait();
                var result = login.Result;
                if (result.IsSuccessStatusCode)
                {
                    var res = result.Content.ReadAsStringAsync().Result;

                    userRes = JsonConvert.DeserializeObject<User>(res);

                    return RedirectToAction("Login", "Login");
                }
            }
            ModelState.AddModelError(string.Empty, "Napaka");
            return View();
        }
    }
}
