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
        private readonly IMapper _mapper;
        public KursKayitController(DataContext context, IMapper mapper)
        {

            _context = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var kursKayitlari = await _context
                        .KursKayitlari
                        .Include(x => x.Ogrenci)
                        .Include(x => x.Kurs)
                        .Include(x => x.Ogretmen)
                        .ToListAsync();

            var mapping = _mapper.Map<List<KursKayitViewModel>>(kursKayitlari);
            return View(mapping);

        }


        public async Task<IActionResult> Create()
        {
            ViewBag.Ogrenciler = new SelectList(await _context.Ogrenciler.ToListAsync(), "OgrenciId", "AdSoyad");
            ViewBag.Kurslar = new SelectList(await _context.Kurslar.ToListAsync(), "KursId", "Baslik");
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




    }
}