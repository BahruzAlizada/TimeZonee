using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timezone.Models
{
	public class BlogModel
	{
		public int Id { get; set; }
		public string Image { get; set; }
		[NotMapped]
		public IFormFile? Photo { get; set; }
		[Required(ErrorMessage ="Bu xana boş ola bilməz")]
		public string Title { get; set; }
        [Required(ErrorMessage = "Bu xana boş ola bilməz")]
        public string Description { get; set; }
	}
}
