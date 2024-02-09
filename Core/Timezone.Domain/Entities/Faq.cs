using Timezone.Domain.Common;

namespace Timezone.Domain.Entities
{
	public class Faq : BaseEntity
	{
		public string Quetsion { get; set; }
		public string Answer { get; set; }
	}
}
