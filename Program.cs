using Microsoft.EntityFrameworkCore;
using Module.Entities;

namespace Module
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			var config = builder.Configuration;
			// Add services to the container.

			builder.Services.AddControllers();

			builder.Services.AddDbContext<MyDbContext>(options =>
			{
				options.UseSqlServer(config.GetConnectionString("test"));
				options.UseLoggerFactory(LoggerFactory.Create(builder => { }));
			});

			builder.Services.AddCors(options =>
			{
				options.AddPolicy("AllowAll",
				builder =>
				{
					builder.AllowAnyOrigin()
						   .AllowAnyMethod()
						   .AllowAnyHeader();
				});
			});

			builder.Services.AddControllersWithViews();

			var app = builder.Build();

			app.UseStaticFiles();
			app.UseHttpsRedirection();

			app.MapControllers();

			app.UseRouting();
			// app.MapGet("/", () => new { Message = "Hello API!" });

			app.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}"
			);

			app.Run();
		}
	}
}
