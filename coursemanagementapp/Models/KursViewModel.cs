using System.ComponentModel.DataAnnotations;

namespace coursemanagementapp.Data
{
   public class KursViewModel
   {
      public int KursId { get; set; }
      public int KayitId { get; set; }

      [Required,]
      [StringLength(50)]
      public string? Ders { get; set; }
      public int OgretmenId { get; set; }
      public int OgrenciId { get; set; }

      public ICollection<KursKayit> KursKayitlari { get; set; } = new List<KursKayit> { };
   }
}