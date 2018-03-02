using System;
using System.Collections.Generic;
namespace oopworkshopcsharpmaster.NetlightTech101OOP.Exercise1.Domain
{
    public class Order
    {
        private String orderId;
        private Customer customer;
        private HashSet<Product> products;

        public Order(Customer customer){
            this.orderId = Guid.NewGuid().ToString();
            this.customer = customer;
            this.products = new HashSet<Product>();
        }

        public void addProduct(Product product)
        {
            this.products.Add(product);
        }

        public HashSet<Product> getProducts()
        {
            return this.products;
        }

        public Customer getCustomer()
        {
            return this.customer;
        }

        public String getOrderId()
        {
            return orderId;
        }
    }
}
