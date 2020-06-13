using BLL.interfaces;
using DAL.interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class CustomerService : ICustomerService
    {
        ICustomerRepository repository;
        public CustomerService(ICustomerRepository _repository)
        {
            repository = _repository;
        }
        public void Add(Customer customer)
        {
            repository.Add(customer);
        }

        public Customer FindById(int id)
        {
            return repository.FindById(id);
        }

        public List<Customer> GetAllCustomers()
        {
            return repository.Get();

        }

        public void Remove(int id)
        {
            repository.Remove(id);
        }

        public void Update(Customer customer)
        {
            repository.Update(customer);
        }
    }
}
