using System;
using System.Linq.Expressions;
using ContactManagement.Domain.Entities;

namespace ContactManagement.Domain.Interface.Repository
{
    public interface IContactUserRepository : IRepository<ContactUser>
    {
	    bool Exist(Expression<Func<ContactUser, bool>> expression);
    }
}