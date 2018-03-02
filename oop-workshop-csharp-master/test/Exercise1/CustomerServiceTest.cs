using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using oopworkshopcsharpmaster.NetlightTech101OOP.Exercise1;
using oopworkshopcsharpmaster.NetlightTech101OOP.Exercise1.Domain;
using oopworkshopcsharpmaster.NetlightTech101OOP.Exercise1.Infrastructure;
namespace oopworkshopcsharpmaster.test.Exercise1
{
    [TestClass]
    public class CustomerServiceTest
    {
        private CustomerService customerService = new CustomerService();

        private SmtpMailClient smtpMailClient = SmtpMailClient.getInstance();

        [TestMethod]
    public void testCreateAndLoadCustomer()
        {

            Customer c = customerService.createCustomer("Mickey", "Mouse");
            String customerId = c.getCustomerId();

            Assert.IsTrue(customerService.exists(customerId));

            Customer loadedCustomer = customerService.getCustomer(customerId);
            Assert.AreEqual("Mickey", loadedCustomer.getFirstName());
        }

        [TestMethod]
    public void testUpdateAndSendEmails()
        {
            Customer c = customerService.createCustomer("Donald", "Duck");
            String customerId = c.getCustomerId();

            customerService.updateCustomerEmailAddress(customerId, "donald.duck@gmail.com");

            Assert.IsTrue(customerService.hasEmail(customerId));

            Customer loadedCustomer = customerService.getCustomer(customerId);
            Assert.AreEqual("donald.duck@gmail.com", loadedCustomer.getEmail());

            customerService.sendEmail(c, "This is a test");

            A emails = smtpMailClient.getMails("donald.duck@gmail.com");
            Assert.AreEqual(1, emails.size());
            Assert.AreEqual("This is a test", emails.get(0));
        }

        [TestMethod]
    public void testPlaceAndGetOrders()
        {
            Customer c = customerService.createCustomer("Woody", "Woodpecker");
            String customerId = c.getCustomerId();
            customerService.updateCustomerEmailAddress(customerId, "woody.woodpecker@gmail.com");

            Product keyboard = customerService.findProduct("Keyboard");
            Product mouse = customerService.findProduct("Mouse");

            Order order = customerService.createOrder(customerId, keyboard.getProductId(), mouse.getProductId());

            customerService.placeOrder(order);
            Money totalOrderCost = customerService.totalOrderCost(order);

            Assert.AreEqual(Money.parse("EUR 40"), totalOrderCost);

            List<String> emails = smtpMailClient.getMails("woody.woodpecker@gmail.com");

        }
    }
}
