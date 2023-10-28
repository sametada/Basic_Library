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

        public IActionResult Ekle ()
        {
            return View();
        }
        [HttpPost]
		public IActionResult Ekle(KitapTuru kitapTuru)
		{
            if (ModelState.IsValid)
            {
				_uygulamaDbContext.KitapTurleri.Add(kitapTuru);
				_uygulamaDbContext.SaveChanges();
                TempData["basarili"] = "Kitap Türü başarıyla oluşturuldu";
				return RedirectToAction("Index", "KitapTuru");
			}
            return View();
		}

		public IActionResult Guncelle(int? id)
		{
			if(id==null || id==0)
			{
				return NotFound();
			}
			KitapTuru? kitapTuruVt = _uygulamaDbContext.KitapTurleri.Find(id);
			if (kitapTuruVt == null)
			{
				return NotFound();
			}
			return View(kitapTuruVt);
		}
		[HttpPost]
		public IActionResult Guncelle(KitapTuru kitapTuru)
		{
			if (ModelState.IsValid)
			{
				_uygulamaDbContext.KitapTurleri.Update(kitapTuru);
				_uygulamaDbContext.SaveChanges();
                TempData["basarili"] = "Kitap Türü başarıyla güncellendi";
                return RedirectToAction("Index", "KitapTuru");
			}
			return View();
		}
        public IActionResult Sil(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            KitapTuru? kitapTuruVt = _uygulamaDbContext.KitapTurleri.Find(id);
            if (kitapTuruVt == null)
            {
                return NotFound();
            }
            return View(kitapTuruVt);
        }
        [HttpPost, ActionName("Sil")]
        public IActionResult SilPOST(int? id)
        {
            KitapTuru? kitapTuru = _uygulamaDbContext.KitapTurleri.Find(id);
            if (kitapTuru == null)
            {
                return NotFound();
            }
            _uygulamaDbContext.KitapTurleri.Remove(kitapTuru);
            _uygulamaDbContext.SaveChanges();
            TempData["basarili"] = "Kitap Türü başarıyla silindi";
            return RedirectToAction("Index", "KitapTuru");
        }

    }
}
