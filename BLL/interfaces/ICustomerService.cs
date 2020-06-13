using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.interfaces
{
    public interface ICustomerService
    {
        List<Customer> GetAllCustomers();
        Customer FindById(int id);
        void Update(Customer customer);
        void Add(Customer customer);
        void Remove(int id);
    }
}
