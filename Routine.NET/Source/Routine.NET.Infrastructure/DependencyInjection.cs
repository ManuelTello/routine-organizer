using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Routine.NET.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;


namespace Routine.NET.Infrastructure
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{
			AddPersistence(services, configuration);
			return services;
		}

		private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("ApplicationConnection") ?? throw new NullReferenceException();

			services.AddDbContext<IdentityContext>(options =>
			{
				options.UseSqlite(connectionString);
			});

			services.AddDbContext<ApplicationContext>(options =>
			{
				options.UseSqlite(connectionString);
			});
			return services;
		}
	}
}