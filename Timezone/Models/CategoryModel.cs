using System.ComponentModel.DataAnnotations;

namespace Timezone.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Bu xana boş ola bilməz")]
        public string CategoryName { get; set; }
    }
}
