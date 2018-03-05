using System;
using System.Collections.Generic;
using oopworkshopcsharpmaster.NetlightTech101OOP.Core;
using oopworkshopcsharpmaster.NetlightTech101OOP.Exercise1;
using oopworkshopcsharpmaster.NetlightTech101OOP.Exercise1.Domain;
using oopworkshopcsharpmaster.NetlightTech101OOP.Exercise1.Infrastructure;
using Xunit;

namespace oop_workshop.Tests.Excercise1
{
    public class CustomerServiceTest
    {
        private CustomerService customerService = new CustomerService();

        private SmtpMailClient smtpMailClient = SmtpMailClient.getInstance();

        [Fact]
        public void testCreateAndLoadCustomer()
        {

            Customer c = customerService.createCustomer("Mickey", "Mouse");
            String customerId = c.getCustomerId();

            Assert.True(customerService.exists(customerId));

            Customer loadedCustomer = customerService.getCustomer(customerId);
            Assert.Equal("Mickey", loadedCustomer.getFirstName());
        }

        [Fact]
        public void testUpdateAndSendEmails()
        {
            Customer c = customerService.createCustomer("Donald", "Duck");
            String customerId = c.getCustomerId();

            customerService.updateCustomerEmailAddress(customerId, "donald.duck@gmail.com");

            Assert.True(customerService.hasEmail(customerId));

            Customer loadedCustomer = customerService.getCustomer(customerId);
            Assert.Equal("donald.duck@gmail.com", loadedCustomer.getEmail());

            customerService.sendEmail(c, "This is a test");

            var emails = smtpMailClient.getMails("donald.duck@gmail.com");
            Assert.Equal(1, emails.Count);
            Assert.Equal("This is a test", emails[0]);
        }

        [Fact]
        public void testPlaceAndGetOrders()
        {
            Customer c = customerService.createCustomer("Woody", "Woodpecker");
            String customerId = c.getCustomerId();
            customerService.updateCustomerEmailAddress(customerId, "woody.woodpecker@gmail.com");

            Product keyboard = customerService.findProduct("Keyboard");
            Product mouse = customerService.findProduct("Mouse");

            Order order = customerService.createOrder(customerId, new String[] { keyboard.getProductId(), mouse.getProductId() });

            customerService.placeOrder(order);
            Money totalOrderCost = customerService.totalOrderCost(order);

            Assert.Equal(new Money(CurrencyUnit.EUR, 40), totalOrderCost);

            List<String> emails = smtpMailClient.getMails("woody.woodpecker@gmail.com");
        }
    }
}
