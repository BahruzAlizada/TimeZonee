using System.ComponentModel.DataAnnotations;

namespace Timezone.Models
{
    public class VacancyModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Bu xana boş ola bilməz")]
        public string VacancyName { get; set; }
        [Required(ErrorMessage = "Bu xana boş ola bilməz")]
        public string Required { get; set; }
        [Required(ErrorMessage = "Bu xana boş ola bilməz")]
        public string VacancyDescription { get; set; }
        [Required(ErrorMessage = "Bu xana boş ola bilməz")]
        public string Salary { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.UtcNow.AddHours(4);
        [Required(ErrorMessage = "Bu xana boş ola bilməz")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
