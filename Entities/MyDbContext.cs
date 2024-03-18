using Microsoft.EntityFrameworkCore;

namespace Module.Entities
{
	public class MyDbContext : DbContext
	{
		public DbSet<Call> Calls { get; set; }
		public DbSet<CallDetail> CallDetails { get; set; }
		public DbSet<ActivityHistory> ActivityHistory { get; set; }
		public DbSet<EventConfiguration> EventConfigurations { get; set; }
		public DbSet<Account> Accounts { get; set; }
		public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
	}
}
