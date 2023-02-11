using ContactManagement.Data.Mapping;
using ContactManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactManagement.Data
{
	public class MariaDbContext : DbContext
	{
		public MariaDbContext(DbContextOptions<MariaDbContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new ContactUserMapping());
			base.OnModelCreating(modelBuilder);
		}
	}
}