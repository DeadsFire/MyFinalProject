using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        private Product productToUpdate;

        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product {CategoryId=1, ProductId=1, ProductName="Bardak", UnitInStock=15, UnitPrice=15},
                new Product {CategoryId=2, ProductId=1, ProductName="Kamera", UnitInStock=3, UnitPrice=500},
                new Product {CategoryId=3, ProductId=2, ProductName="Telefon", UnitInStock=2, UnitPrice=1500},
                new Product {CategoryId=4, ProductId=2, ProductName="Klavye", UnitInStock=65, UnitPrice=150},
                new Product {CategoryId=5, ProductId=2, ProductName="Fare", UnitInStock=1, UnitPrice=85}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ - Language Integrated Query
            Product productToDelete = null;
            foreach (var p in _products)
            {
                if (product.ProductId == p.ProductId)
                {
                    productToDelete = p;
                }
            }

            productToDelete = _products.SingleOrDefault(p=>p.ProductId ==product.ProductId);

            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            //Gönderdiğim ürün id'sine sahip olan listedeki ürünü bul
            productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitInStock = product.UnitInStock;
        }
    }
}
