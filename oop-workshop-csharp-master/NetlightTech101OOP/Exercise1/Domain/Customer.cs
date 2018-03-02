using System;
namespace oopworkshopcsharpmaster.NetlightTech101OOP.Exercise1.Domain
{
    public class Customer
    {

        private String customerId;
        private String firstName;
        private String lastName;
        private String email;

        public Customer(String firstName, String lastName, String email)
        {
            this.customerId = Guid.NewGuid().ToString();
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
        }

        public String getCustomerId()
        {
            return customerId;
        }

        public String getFirstName()
        {
            return firstName;
        }

        public void setFirstName(String firstName)
        {
            this.firstName = firstName;
        }

        public String getLastName()
        {
            return lastName;
        }

        public void setLastName(String lastName)
        {
            this.lastName = lastName;
        }

        public String getEmail()
        {
            return email;
        }

        public void setEmail(String email)
        {
            this.email = email;
        }
        public Customer()
        {
        }
    }
}
