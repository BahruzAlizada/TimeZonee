using System.ComponentModel.DataAnnotations;

namespace Timezone.ViewsModel
{
    public class ResetPasswordVM
    {
        [Required(ErrorMessage = "Bu xana boş ola bilməz")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Bu xana boş ola bilməz")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Şifrə düzgün deyil ")]
        public string CheckNewPassword { get; set; }
    }
}
