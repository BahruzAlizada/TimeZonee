using System.ComponentModel.DataAnnotations;

namespace Timezone.Models
{
    public sealed class ContactModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Bu xana boş ola bilməz")]
        public string Message { get; set; }
        [Required(ErrorMessage = "Bu xana boş ola bilməz")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Bu xana boş ola bilməz")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Bu xana boş ola bilməz")]
        public string Subject { get; set; }
    }
}
