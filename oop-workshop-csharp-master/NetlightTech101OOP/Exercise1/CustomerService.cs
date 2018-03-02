using System;
using oopworkshopcsharpmaster.NetlightTech101OOP.Exercise1.Infrastructure;
using oopworkshopcsharpmaster.NetlightTech101OOP.Exercise1.Domain;
namespace oopworkshopcsharpmaster.NetlightTech101OOP.Exercise1
{
    public class CustomerService
    {
        private CustomerRepository customerRepository = CustomerRepository.getInstance();
        private ProductRepository productRepository = ProductRepository.getInstance();
        private OrderRepository orderRepository = OrderRepository.getInstance();
        private SmtpMailClient smtpMailClient = SmtpMailClient.getInstance();

        public Customer createCustomer(String firstName, String lastName)
        {
            Customer c = new Customer(firstName, lastName, null);
            customerRepository.save(c);
            return c;
        }

        public void updateCustomerEmailAddress(String customerId, String newEmail)
        {
            Customer c = customerRepository.findById(customerId);
            c.setEmail(newEmail);
        }

        public Boolean exists(String customerId)
        {
            return customerRepository.findById(customerId) != null;
        }

        public Customer getCustomer(String customerId)
        {
            return customerRepository.findById(customerId);
        }

        public Boolean hasEmail(String customerId)
        {
            Customer customer = customerRepository.findById(customerId);
            return customer.getEmail() != null;
        }

        public int totalProducts()
        {
            return productRepository.findAll().Count;
        }

        public Order createOrder(String customerId, String...productIds)
        {
            Customer c = customerRepository.findById(customerId);
            Order order = new Order(c);

            foreach (String id in productIds)
            {
                Product p = productRepository.findById(id);
                order.addProduct(p);
            }

            return order;
        }

        public Product findProduct(String productName)
        {
            return productRepository.findByName(productName);
        }

        public Money totalOrderCost(Order order)
        {
            Money total = Money.zero(CurrencyUnit.EUR);
            foreach (Product p in order.getProducts())
            {
                total = total.plus(p.getPrice());
            }
            return total;
        }

        public void placeOrder(Order order)
        {
            orderRepository.save(order);
            sendEmail(order.getCustomer(), "Thank you for your order!");
        }

        public void sendEmail(Customer customer, String message)
        {
            if (hasEmail(customer.getCustomerId()))
            {
                smtpMailClient.sendEmail(customer.getEmail(), message);
            }
        }

    }
}
