using System.ComponentModel.DataAnnotations;
using Timezone.Domain.Common;

namespace Timezone.Domain.Entities
{
	public class Slider : BaseEntity
	{
		[Required(ErrorMessage = "Bu xana boş ola bilməz")]
		public string Title { get; set; }
		public string SubTitle { get; set; }
	}
}
