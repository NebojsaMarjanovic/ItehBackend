using DataAccessLayer.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Implementations
{
    public class UserRepository : IUserRepository
    {
        //dependency injection
        private readonly Context context;

        public UserRepository(Context context)
        {
            this.context = context;
        }

        public void Add(User entity)
        {
            context.Users.Add(entity);
        }

        public void Delete(User entity)
        {
            context.Users.Remove(entity);
        }

        public List<User> GetAll()
        {
            return context.Users.ToList();
        }

        public User SearchById(User entity)
        {
            return context.Users.Single(u => u.UserId == entity.UserId);
        }

        public List<User> SerachBy(Expression<Func<User, bool>> predicate)
        {
            return context.Users.Where(predicate).ToList();
        }

        public void Update(User entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
