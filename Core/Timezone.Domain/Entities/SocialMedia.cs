using System.ComponentModel.DataAnnotations;
using Timezone.Domain.Common;

namespace Timezone.Domain.Entities
{
	public class SocialMedia : BaseEntity
	{
		[Required(ErrorMessage = "Bu xana boş ola bilməz")]
		public string Icon { get; set; }
		[Required(ErrorMessage = "Bu xana boş ola bilməz")]
		public string Link { get; set; }
	}
}
