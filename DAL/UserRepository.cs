using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DAL.interfaces;

namespace DAL
{
    public class UserRepository : IUserRepository
    {
        DataContext context;
        public UserRepository(DataContext _context)
        {
            context = _context;

        }
        public List<User> Get()
        {
            return context.Users.ToList();
        }

        public User FindById(int id)
        {
            return context.Users.Where(u => u.Id == id).Single();
        }

        public void Save(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}
