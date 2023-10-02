using System.ComponentModel.DataAnnotations;

namespace Timezone.ViewsModel
{
    public class RoleListVM
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Bu xana boş ola bilməz")]
        public string Role { get; set; }
    }
}
