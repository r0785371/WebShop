using BLL.interfaces;
using DAL;
using DAL.interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class Userservice : IUserService
    {
        IUserRepository repository;
        public Userservice(IUserRepository _repository)
        {
            repository = _repository;
        }
        public List<User> GetAllUsers()
        {
            return repository.Get();
        }

        public void Save(User user)
        {
            repository.Save(user);
        }
    }
}
