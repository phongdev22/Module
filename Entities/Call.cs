using System.ComponentModel.DataAnnotations;

namespace Module.Entities
{
	public class Call
	{
		[Key]
		public required string CallId { get; set; }
		public required string AccountSid { get; set; }
		public required string From { get; set; }
		public required string To { get; set; }
		public long? TimeStart { get; set; }
	}
}
