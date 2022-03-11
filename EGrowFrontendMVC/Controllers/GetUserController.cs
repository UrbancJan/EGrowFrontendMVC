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
    public class GetUserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult GetUser()
        {
            if (HttpContext.Session.GetString("userID") != null)
            {
                //var userId = this.Request.Cookies["userId"];
                var userId = HttpContext.Session.GetString("userID");

                User userRes = new User();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(UrlPovezava.urlPovezava + "User/");
                    var getUserById = client.GetAsync(userId);
                    getUserById.Wait();
                    var result = getUserById.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var res = result.Content.ReadAsStringAsync().Result;
                        userRes = JsonConvert.DeserializeObject<User>(res);
                        return View(userRes);
                    }
                }
                ModelState.AddModelError(string.Empty, "Napaka");
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
