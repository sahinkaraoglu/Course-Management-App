using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace coursemanagementapp.Data
{

    public class OgretmenViewModel
    {
        [DisplayName("Öğretmen Ad Soyad")]
        public string? AdSoyad { get; set; }     
    }


}
