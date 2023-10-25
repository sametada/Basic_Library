using Microsoft.AspNetCore.Mvc;
using WebApplication_01.Models;
using WebApplication_01.Utility;

namespace WebApplication_01.Controllers
{
    public class KitapTuruController : Controller
    {
        private readonly UygulamaDbContext _uygulamaDbContext;

        public KitapTuruController(UygulamaDbContext context)
        {
            _uygulamaDbContext = context;   
        }   
        public IActionResult Index()
        {
            List<KitapTuru> objKitapTuruList = _uygulamaDbContext.KitapTurleri.ToList();
            return View(objKitapTuruList);
        }

    }
}
