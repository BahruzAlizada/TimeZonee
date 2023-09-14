using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timezone.Models
{
	public class SliderModel
	{
		public int Id { get; set; }
		[Required(ErrorMessage ="Bu xana boş ola bilməz")]
		public string Title { get; set; }
		[Required(ErrorMessage = "Bu xana boş ola bilməz")]
		public string SubTitle { get; set; }
		public string Image { get; set; }
		[NotMapped]
		public IFormFile? Photo { get; set; }
	}
}
