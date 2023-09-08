using System.ComponentModel.DataAnnotations;

namespace Timezone.Models
{
    public class AboutModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Bu xana boş ola bilməz")]
        public string Vision { get; set; }
        [Required(ErrorMessage ="Bu xana boş ola bilməz")]
        public string Mision { get; set; }
    }
}
