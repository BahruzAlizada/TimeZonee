using System.ComponentModel.DataAnnotations;

namespace Timezone.Models
{
    public class ShopMethodModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Bu xana boş ola bilməz")]
        public string Icon { get; set; }
        [Required(ErrorMessage = "Bu xana boş ola bilməz")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Bu xana boş ola bilməz")]
        public string Description { get; set; }
    }
}
