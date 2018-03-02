using System;
using oopworkshopcsharpmaster.NetlightTech101OOP.Exercise1.Domain;
using System.Collections.Generic;

namespace oopworkshopcsharpmaster.NetlightTech101OOP.Exercise1.Infrastructure
{
    public class CustomerRepository
    {
        private static CustomerRepository instance;

        private HashSet<Customer> customerData = new HashSet<Customer>();

        public static CustomerRepository getInstance()
        {
            if (instance == null)
            {
                instance = new CustomerRepository();
            }
            return instance;
        }

        private CustomerRepository()
        {
            initData();
        }

        private void initData()
        {
            customerData.Add(new Customer("Joe", "Bloggs", "joe.bloggs@hotmail.com"));
            customerData.Add(new Customer("Lucy", "Smith", null));
            customerData.Add(new Customer("Fischer", "Fritz", "frische.fische@gmail.com"));
            customerData.Add(new Customer("Amanda", "Jones", "amanda.jones@gmail.com"));
        }

        public Customer findById(String customerId)
        {
            foreach (Customer c in customerData)
            {
                if (customerId.Equals(c.getCustomerId()))
                {
                    return c;
                }
            }
            return null;
        }

        public HashSet<Customer> findAll()
        {
            return customerData;
        }

        public void save(Customer customer)
        {
            this.customerData.Add(customer);
        }
    }
}
