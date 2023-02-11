using Microsoft.EntityFrameworkCore;

namespace ContactManagement.Domain.Repository
{
	public abstract class Repository<TDbContext> where TDbContext : DbContext
	{
		protected virtual TDbContext DbContext { get; }

		public Repository(TDbContext dbContext)
		{
			DbContext = dbContext;
		}

		public void Commit()
		{
			DbContext.SaveChanges();
		}
	}
}