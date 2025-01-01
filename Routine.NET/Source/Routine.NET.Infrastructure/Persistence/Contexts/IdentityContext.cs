using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Routine.NET.Infrastructure.Persistence.Contexts
{
	public class IdentityContext:IdentityDbContext<IdentityUser>
	{
		public IdentityContext(DbContextOptions<IdentityContext> options):base(options){}
	}
}