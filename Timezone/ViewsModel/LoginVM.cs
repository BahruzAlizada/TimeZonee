using System.ComponentModel.DataAnnotations;

namespace Timezone.ViewsModel
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Email can not be null")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password can not be null")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool IsRemember { get; set; }
    }
}
