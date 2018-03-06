using System;
using oopworkshopcsharpmaster.NetlightTech101OOP.Exercise1.Domain;
using System.Collections.Generic;
using oopworkshopcsharpmaster.NetlightTech101OOP.Core;

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
            productData.Add(new Product("Keyboard", "Mechanical computer keyboard", new Money(CurrencyUnit.EUR, 25)));
            productData.Add(new Product("Mouse", "Amazing computer mouse", new Money(CurrencyUnit.EUR, 15)));
            productData.Add(new Product("LCD Monitor", "Hi res display", new Money(CurrencyUnit.EUR, 350)));
            productData.Add(new Product("Speakers", "Very loud speakers for music and games", new Money(CurrencyUnit.EUR, 150)));
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
