using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string? Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsVerify { get; set; }
        public bool IsSalesAccount { get; set; }
        public string? Bio { get; set; }
    }
}
