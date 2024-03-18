using System.ComponentModel.DataAnnotations;

namespace Module.Entities
{
	public class Account
	{
		[Key]
		public required string Id { get; set; }
		public required string IdentityCode { get; set; }
		public required string Username { get; set; }
		public required string Password { get; set; }
	}
}
