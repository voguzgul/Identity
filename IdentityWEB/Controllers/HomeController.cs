using Microsoft.AspNetCore.Mvc;

namespace IdentityWEB.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
