using System;
using oopworkshopcsharpmaster.NetlightTech101OOP.Exercise1.Domain;
using System.Collections.Generic;

namespace oopworkshopcsharpmaster.NetlightTech101OOP.Exercise1.Infrastructure
{
    public class OrderRepository
    {

    private static OrderRepository instance;

        private HashSet<Order> orderData = new HashSet<Order>();

        public static OrderRepository getInstance()
        {
            if (instance == null)
            {
                instance = new OrderRepository();
            }
            return instance;
        }

        private OrderRepository()
        {

        }

        public Order findById(String orderId)
        {
            foreach (Order c in orderData)
            {
                if (orderId.Equals(c.getOrderId()))
                {
                    return c;
                }
            }
            return null;
        }

        public HashSet<Order> findAll()
        {
            return orderData;
        }

        public void save(Order order)
        {
            this.orderData.Add(order);
        }
    }
}
