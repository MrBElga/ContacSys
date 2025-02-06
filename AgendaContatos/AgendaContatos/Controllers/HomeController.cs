using System.Diagnostics;
using AgendaContatos.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgendaContatos.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpGet]
        public IActionResult GetTheme()
        {
            var theme = Request.Cookies["theme"] ?? "light"; 
            return Json(new { theme });
        }
        [HttpPost]
        public IActionResult ToggleTheme([FromBody] ThemeRequest request)
        {
            var newTheme = request.Theme; 

            Response.Cookies.Append("theme", newTheme, new CookieOptions
            {
                Expires = DateTime.UtcNow.AddYears(1), 
                HttpOnly = false,
                Secure = true 
            });

            return Ok();
        }

        public class ThemeRequest
        {
            public required string Theme { get; set; }
        }
    }
}
