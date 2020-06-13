using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.interfaces
{
    public interface ICustomerRepository
    {
        List<Customer> Get();
        Customer FindById(int id);
        void Update(Customer customer);
        void Add(Customer customer);
        void Remove(int id);

    }
}
