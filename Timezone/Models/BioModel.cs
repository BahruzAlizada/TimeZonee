using System.ComponentModel.DataAnnotations;

namespace Timezone.Models
{
    public class BioModel
    {
        public int Id { get; set; }
        public string HeaderImage { get; set; }
        public IFormFile? HeaderPhoto { get; set; }
        public string FooterImage { get; set; }
        public IFormFile? FooterPhoto { get; set; }
        [Required(ErrorMessage ="Bu xana boş ola bilməz")]
        public string FooterDescription { get; set; }
    }
}
