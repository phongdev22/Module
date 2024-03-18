using System.ComponentModel.DataAnnotations;

namespace Module.Entities
{
	public class CallDetail
	{
		[Key]
		public required string CallId { get; set; }
		public long? AnswerDuration { get; set; }
		public long? TimeEnd { get; set; }
		public long? Duration { get; set; }
		public string? EndedBy { get; set; }
		public string? EndedCause { get; set; }
		public string? Status { get; set; }
	}
}
