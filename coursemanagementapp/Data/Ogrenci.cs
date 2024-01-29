using System.ComponentModel.DataAnnotations;

namespace coursemanagementapp.Data
{
    public class Ogrenci
    {
        [Key]
        [Display(Name = "Öğrenci Id")]
        public int OgrenciId { get; set; }

        [Display(Name = "Ad")]
        public string? OgrenciAd { get; set; }
        [Display(Name = "Soyad")]
        public string? OgrenciSoyad { get; set; }

        [Display(Name = "Öğrenci Ad Soyad")]
        public string? AdSoyad
        {
            get
            {
                return this.OgrenciAd + " " + this.OgrenciSoyad;
            }
        }
        public string? Eposta { get; set; }
        public string? Telefon { get; set; }

        public ICollection<KursKayit> KursKayitlari { get; set; } = new List<KursKayit> { };
    }
}