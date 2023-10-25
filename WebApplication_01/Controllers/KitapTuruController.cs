using Microsoft.AspNetCore.Mvc;

namespace WebApplication_01.Controllers
{
    public class KitapTuruController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
