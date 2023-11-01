using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication_01.Models;
using WebApplication_01.Utility;

namespace WebApplication_01.Controllers
{
    public class KitapController : Controller
    {
        private readonly IKitapRepository _kitapRepository;
        private readonly IKitapTuruRepository _kitapTuruRepository;

        public KitapController(IKitapRepository kitapRepository, IKitapTuruRepository kitapTuruRepository)
        {
			_kitapRepository = kitapRepository;
			_kitapTuruRepository = kitapTuruRepository;
        }   
        public IActionResult Index()
        {
            List<Kitap> objKitapList = _kitapRepository.GetAll().ToList();
            return View(objKitapList);
        }

        public IActionResult Ekle ()
        {
			IEnumerable<SelectListItem> KitapTuruList = _kitapTuruRepository.GetAll().Select(k => new SelectListItem
			{
				Text = k.Ad,//kitaplar çekilir ve combobox a aktarılır 
				Value = k.Id.ToString()
			});
            ViewBag.KitapTuruList = KitapTuruList; // controller dan view e veri aktarma tek yönlüdür view den controllar a aktarılmaz
			return View();
        }
        [HttpPost]
		public IActionResult Ekle(Kitap kitap)
		{
            if (ModelState.IsValid)
            {
				_kitapRepository.Ekle(kitap);
				_kitapRepository.Kaydet();
                TempData["basarili"] = "Kitap başarıyla oluşturuldu";
				return RedirectToAction("Index", "Kitap");
			}
            return View();
		}

		public IActionResult Guncelle(int? id)
		{
			if(id==null || id==0)
			{
				return NotFound();
			}
			Kitap? kitapVt = _kitapRepository.Get(u=>u.Id==id);
			if (kitapVt == null)
			{
				return NotFound();
			}
			return View(kitapVt);
		}
		[HttpPost]
		public IActionResult Guncelle(Kitap kitap)
		{
			if (ModelState.IsValid)
			{
				_kitapRepository.Guncelle(kitap);
				_kitapRepository.Kaydet();
                TempData["basarili"] = "Kitap başarıyla güncellendi";
                return RedirectToAction("Index", "Kitap");
			}
			return View();
		}
        public IActionResult Sil(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Kitap? kitapVt = _kitapRepository.Get(u => u.Id == id);
			if (kitapVt == null)
            {
                return NotFound();
            }
            return View(kitapVt);
        }
        [HttpPost, ActionName("Sil")]
        public IActionResult SilPOST(int? id)
        {
            Kitap? kitap = _kitapRepository.Get(u => u.Id == id);
			if (kitap == null)
            {
                return NotFound();
            }
            _kitapRepository.Sil(kitap);
			_kitapRepository.Kaydet();
            TempData["basarili"] = "Kitap başarıyla silindi";
            return RedirectToAction("Index", "Kitap");
        }

    }
}
