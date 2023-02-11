using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ContactManagement.Domain.Entities;
using ContactManagement.Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;

namespace ContactManagement.Domain.Repository
{
	public class ContactUserRepository<TDbContext> : Repository<TDbContext>, IContactUserRepository
		where TDbContext : DbContext
	{
		protected DbSet<ContactUser> Crud => DbContext.Set<ContactUser>();
		protected IQueryable<ContactUser> Queryable => DbContext.Set<ContactUser>().AsNoTracking();

		public ContactUserRepository(TDbContext dbContext) : base(dbContext)
		{
		}

		public ContactUser Add(ContactUser entity)
		{
			Crud.Add(entity);
			Commit();
			return entity;
		}

		public ContactUser Get(int id)
		{
			return Queryable.FirstOrDefault(c => c.Id == id);
		}

		public void Update(ContactUser entity)
		{
			Crud.Update(entity);
			Commit();
		}

		public IEnumerable<ContactUser> GetAll()
		{
			return Queryable.ToList();
		}

		public void Delete(int id)
		{
			var entity = Get(id);
			Crud.Remove(entity);
			Commit();
		}

		public bool Exist(Expression<Func<ContactUser, bool>> expression)
		{
			var entity = Queryable.Where(expression).FirstOrDefault();
			return entity != null;
		}
	}
}