using System;
namespace oopworkshopcsharpmaster.NetlightTech101OOP.Exercise1.Domain
{
    public class Product
    {
        private readonly  String productId;
        private readonly  String productName;
        private readonly  String productDescription;
        private readonly  Money price;

    public Product(String productName, String productDescription, Money price)
        {
            this.productId = Guid.NewGuid().ToString();
            this.productName = productName;
            this.productDescription = productDescription;
            this.price = price;
        }

        public String getProductId()
        {
            return productId;
        }

        public String getProductName()
        {
            return productName;
        }

        public String getProductDescription()
        {
            return productDescription;
        }

        public Money getPrice()
        {
            return price;
        }
    }
}
