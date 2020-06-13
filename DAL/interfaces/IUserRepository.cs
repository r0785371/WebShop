using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.interfaces
{
   public interface IUserRepository
    {
        List<User> Get();
        User FindById(int id);
        void Save(User user);
    }
}
