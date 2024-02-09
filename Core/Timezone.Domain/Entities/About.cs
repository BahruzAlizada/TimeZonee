using System.ComponentModel.DataAnnotations;
using Timezone.Domain.Common;

namespace Timezone.Domain.Entities
{
	public class About : BaseEntity
	{
		[Required(ErrorMessage = "Bu xana boş ola bilməz")]
		public string Description { get; set; }
	}
}
