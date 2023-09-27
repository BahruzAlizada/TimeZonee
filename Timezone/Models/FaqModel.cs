using System.ComponentModel.DataAnnotations;

namespace Timezone.Models
{
    public class FaqModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Bu xana boş ola bilməz")]
        public string Quetsion { get; set; }
        [Required(ErrorMessage = "Bu xana boş ola bilməz")]
        public string Answer { get; set; }
    }
}
