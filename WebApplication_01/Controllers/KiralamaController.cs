using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication_01.Models;
using WebApplication_01.Utility;

namespace WebApplication_01.Controllers
{
    public class KiralamaController : Controller
    {
		private readonly IKiralamaRepository _kiralamaRepository;
        private readonly IKitapRepository _kitapRepository;

        public readonly IWebHostEnvironment _webHostEnvironment;

        public KiralamaController(IKiralamaRepository kiralamaRepository, IKitapRepository kitapRepository, IWebHostEnvironment webHostEnvironment)
        {
			_kiralamaRepository = kiralamaRepository;
			_kitapRepository = kitapRepository;
            _webHostEnvironment = webHostEnvironment;
        }   
        public IActionResult Index()
        {
            List<Kiralama> objKiralamaList = _kiralamaRepository.GetAll(includeProps:"Kitap").ToList();
            return View(objKiralamaList);
        }

        public IActionResult EkleGuncelle (int? id)
        {
			IEnumerable<SelectListItem> KitapList = _kitapRepository.GetAll().Select(k => new SelectListItem
			{
				Text = k.KitapAdi,//kitaplar çekilir ve combobox a aktarılır 
				Value = k.Id.ToString()
			});
            ViewBag.KitapList = KitapList; // controller dan view e veri aktarma tek yönlüdür view den controllar a aktarılmaz

            if(id==null || id == 0)
            {
                //ekleme
                return View();
            }
            else
            {
				//guncelleme 
				Kiralama? kiralamaVt = _kiralamaRepository.Get(u => u.Id == id);
				if (kiralamaVt == null)
				{
					return NotFound();
				}
				return View(kiralamaVt);
			}
        }
        [HttpPost]
		public IActionResult EkleGuncelle(Kiralama kiralama)
		{
            if (ModelState.IsValid)
            {

                if (kiralama.Id==0)
                {
					_kiralamaRepository.Ekle(kiralama);
					TempData["basarili"] = "Yeni kiralama başarıyla oluşturuldu";
				}
                else
                {
                    _kiralamaRepository.Guncelle(kiralama);
					TempData["basarili"] = "Kiralama kayıtları başarıyla güncellendi";
				}
				_kiralamaRepository.Kaydet();

				return RedirectToAction("Index", "Kiralama");
			}
            return View();
		}

		public IActionResult Sil(int? id)
        {

			IEnumerable<SelectListItem> KitapList = _kitapRepository.GetAll().Select(k => new SelectListItem
			{
				Text = k.KitapAdi,
				Value = k.Id.ToString()
			});
			ViewBag.KitapList = KitapList;

			if (id == null || id == 0)
            {
                return NotFound();
            }
            Kiralama? kiralamaVt = _kiralamaRepository.Get(u => u.Id == id);
			if (kiralamaVt == null)
            {
                return NotFound();
            }
            return View(kiralamaVt);
        }
        [HttpPost, ActionName("Sil")]
        public IActionResult SilPOST(int? id)
        {
            Kiralama? kiralama = _kiralamaRepository.Get(u => u.Id == id);
			if (kiralama == null)
            {
                return NotFound();
            }
            _kiralamaRepository.Sil(kiralama);
			_kiralamaRepository.Kaydet();
            TempData["basarili"] = "Kitap başarıyla silindi";
            return RedirectToAction("Index", "Kiralama");
        }

    }
}
