﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication_01.Models;
using WebApplication_01.Utility;

namespace WebApplication_01.Controllers
{
    [Authorize(Roles = UserRoles.Role_Admin)]
    public class KitapTuruController : Controller
    {
        private readonly IKitapTuruRepository _kitapTuruRepository;

        public KitapTuruController(IKitapTuruRepository context)
        {
			_kitapTuruRepository = context;   
        }   
        public IActionResult Index()
        {
            List<KitapTuru> objKitapTuruList = _kitapTuruRepository.GetAll().ToList();
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
				_kitapTuruRepository.Ekle(kitapTuru);
				_kitapTuruRepository.Kaydet();
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
			KitapTuru? kitapTuruVt = _kitapTuruRepository.Get(u=>u.Id==id);
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
				_kitapTuruRepository.Guncelle(kitapTuru);
				_kitapTuruRepository.Kaydet();
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
            KitapTuru? kitapTuruVt = _kitapTuruRepository.Get(u => u.Id == id);
			if (kitapTuruVt == null)
            {
                return NotFound();
            }
            return View(kitapTuruVt);
        }
        [HttpPost, ActionName("Sil")]
        public IActionResult SilPOST(int? id)
        {
            KitapTuru? kitapTuru = _kitapTuruRepository.Get(u => u.Id == id);
			if (kitapTuru == null)
            {
                return NotFound();
            }
            _kitapTuruRepository.Sil(kitapTuru);
			_kitapTuruRepository.Kaydet();
            TempData["basarili"] = "Kitap Türü başarıyla silindi";
            return RedirectToAction("Index", "KitapTuru");
        }

    }
}
