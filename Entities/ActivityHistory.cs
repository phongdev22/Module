using System.ComponentModel.DataAnnotations;

namespace Module.Entities
{
	public class ActivityHistory
	{
		[Key]
		public required string CallId { get; set; }
		public required string Recipient { get; set; }
		public required string Status { get; set; }
		public required string StatusMessage { get; set; }
		public DateTime Times { get; set; } = DateTime.UtcNow;
	}
}
