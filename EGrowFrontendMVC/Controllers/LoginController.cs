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
using System.Web;

namespace EGrowFrontendMVC.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserResponse user)
        {
            User userRes = new User();
            using (var client = new HttpClient())
            {
                //client.BaseAddress = new Uri("https://localhost:44319/api/Login");
                client.BaseAddress = new Uri(UrlPovezava.urlPovezava + "Login");
                var login = client.PostAsJsonAsync<UserResponse>("Login", user);
                login.Wait();
                var result = login.Result;
                if (result.IsSuccessStatusCode)
                {
                    var res = result.Content.ReadAsStringAsync().Result;

                    userRes = JsonConvert.DeserializeObject<User>(res);

                    this.Response.Cookies.Append("userId", userRes.userId.ToString());
                    this.Response.Cookies.Append("userGuid", userRes.userGuid);
                    this.Response.Cookies.Append("username", userRes.username);

                    var userGuid = this.Request.Cookies["userGuid"];

                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError(string.Empty, "Napaka");
            return View();
        }
    }
}
