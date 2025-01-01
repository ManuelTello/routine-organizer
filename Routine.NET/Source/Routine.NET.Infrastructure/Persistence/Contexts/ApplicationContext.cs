using Microsoft.EntityFrameworkCore;

namespace Routine.NET.Infrastructure.Persistence.Contexts
{
	public class ApplicationContext:DbContext
	{
		public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options){}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			var assembly = typeof(ApplicationContext).Assembly;
			modelBuilder.ApplyConfigurationsFromAssembly(assembly);
		}
	}
}