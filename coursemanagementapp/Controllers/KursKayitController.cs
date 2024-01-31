using AutoMapper;
using coursemanagementapp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace coursemanagementapp.Controllers
{

    public class KursKayitController : Controller
    {
        private readonly DataContext _context;
        public KursKayitController(DataContext context)
        {

            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var kursKayitlari = await _context
                        .KursKayitlari
                        .Include(x => x.Ogrenci)
                        .Include(x => x.Kurs)
                        .Include(x => x.Ogretmen)
                        .ToListAsync();

            return View(kursKayitlari);

        }


        public async Task<IActionResult> Create()
        {
            ViewBag.Ogrenciler = new SelectList(await _context.Ogrenciler.ToListAsync(), "OgrenciId", "AdSoyad");
            ViewBag.Kurslar = new SelectList(await _context.Kurslar.ToListAsync(), "KursId", "Ders");
            ViewBag.Ogretmenler = new SelectList(await _context.Ogretmenler.ToListAsync(), "OgretmenId", "AdSoyad");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(KursKayit model)
        {
            model.KayitTarihi = DateTime.Now;
            _context.KursKayitlari.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");

        }




        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Kurskayit = await _context.KursKayitlari.FindAsync(id);
            if (Kurskayit == null)
            {
                return NotFound();
            }
            return View(Kurskayit);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] int id)
        {
            var kurskayit = await _context.KursKayitlari.FindAsync(id);
            if (kurskayit == null)
            {
                return NotFound();
            }
            _context.KursKayitlari.Remove(kurskayit);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }



    }
}