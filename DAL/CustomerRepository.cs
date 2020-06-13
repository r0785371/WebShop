using DAL.interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DAL
{
    public class CustomerRepository : ICustomerRepository
    {
        DataContext context;
        public CustomerRepository(DataContext _context)
        {
            context = _context;
        }
        public void Add(Customer customer)
        {
            context.Customers.Add(customer);
            context.SaveChanges();
        }

        public Customer FindById(int id)
        {
            return context.Customers.Where(c => c.CustomerId == id).Single();
        }

        public List<Customer> Get()
        {
            return context.Customers.ToList();
        }

        public void Remove(int id)
        {
            var customer = context.Customers.SingleOrDefault(r => r.CustomerId == id);
            context.Customers.Remove(customer);
            context.SaveChanges();
        }

        public void Update(Customer customer)
        {
            context.Customers.Update(customer);
            context.SaveChanges();
        }
    }


}
