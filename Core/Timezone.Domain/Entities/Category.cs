using System.ComponentModel.DataAnnotations;
using Timezone.Domain.Common;

namespace Timezone.Domain.Entities
{
	public class Category : BaseEntity
	{
		[Required(ErrorMessage ="Bu xana boş ola bilməz")]
		public string Name { get; set; }
		public ICollection<Product> Products { get; set; }
	}
}
