using System;
using oopworkshopcsharpmaster.NetlightTech101OOP.Exercise1.Domain;
using System.Collections.Generic;

namespace oopworkshopcsharpmaster.NetlightTech101OOP.Exercise1.Infrastructure
{
    public class ProductRepository
    {
        private static ProductRepository instance;

        private HashSet<Product> productData = new HashSet<Product>();

        public static ProductRepository getInstance()
        {
            if (instance == null)
            {
                instance = new ProductRepository();
            }
            return instance;
        }

        private ProductRepository()
        {
            initData();
        }

        private void initData()
        {
            productData.Add(new Product("Keyboard", "Mechanical computer keyboard", Money.parse("EUR 25")));
            productData.Add(new Product("Mouse", "Amazing computer mouse", Money.parse("EUR 15")));
            productData.Add(new Product("LCD Monitor", "Hi res display", Money.parse("EUR 350")));
            productData.Add(new Product("Speakers", "Very loud speakers for music and games", Money.parse("EUR 150")));
        }

        public Product findById(String productId)
        {
            foreach (Product p in productData)
            {
                if (productId.Equals(p.getProductId()))
                {
                    return p;
                }
            }
            return null;
        }

        public Product findByName(String productName)
        {
            foreach (Product p in productData)
            {
                if (productName.Equals(p.getProductName()))
                {
                    return p;
                }
            }
            return null;
        }

        public HashSet<Product> findAll()
        {
            return productData;
        }

        public void save(Product product)
        {
            this.productData.Add(product);
        }

    }
}
