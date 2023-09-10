using System.ComponentModel.DataAnnotations;

namespace Timezone.ViewsModel
{
    public class UserVM
    {
        [Required(ErrorMessage = "Bu xana boş ola bilməz")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Bu xana boş ola bilməz")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Bu xana boş ola bilməz")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Bu xana boş ola bilməz")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email ünvanınızı düzgün qeyd edin")]
        public string Email { get; set; }       
    }
}
