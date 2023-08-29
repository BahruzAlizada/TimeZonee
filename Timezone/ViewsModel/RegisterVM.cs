using System.ComponentModel.DataAnnotations;

namespace Timezone.ViewsModel
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Name can not be null")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Surname can not be null")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "UserName can not be null")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email can not be null")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password can not be null")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Password can not be null")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string CheckPassword { get; set; }
        public bool IsRemember { get; set; }
    }
}
