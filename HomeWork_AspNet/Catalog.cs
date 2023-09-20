using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;
using HomeWork_AspNet;

namespace HomeWork_AspNet

{
    public class Catalog
    {
        private readonly List<Product> _products = new()
        {
            new("Ноутбук", 50000),
            new("Смартфон", 25000),
            new("Наушники", 5000),
            new("Монитор", 15000),
            new("Клавиатура", 3000),
            new("Мышь", 1000),
            new("Коврик для мыши", 500),
            new("Флешка", 1000),
            new("Жесткий диск", 5000),
            new("SSD", 8000),
            new("Видеокарта", 30000),
            new("Процессор", 15000),
            new("Материнская плата", 10000),
            new("Оперативная память", 5000),
            new("Блок питания", 5000)
        };

        public Product[] GetProducts()
        {
            return _products.ToArray();
        }

        public Product GetProduct(string productName)
        {
            return _products.First(p => p.Name == productName);
        }

        public void AddProducts(Product product)
        {
            _products.Add(product);
        }

        public void DelProducts(Product product)
        {
            _products.Remove(product);
        }

        public void PutProducts(string productName, Product product)
        {
            var existingProduct = _products.FirstOrDefault(p => p.Name == productName);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
            }
        }



        //Многопоточность
        private SemaphoreSlim _semaphore = new SemaphoreSlim(1);
        public async Task<List<Product>> GetProductsAsync()
        {
            await _semaphore.WaitAsync();
            try
            {
                return _products.ToList();
            }
            finally
            {
                _semaphore.Release();
            }
        }
        public async Task AddProductsAsync(Product product)
        {
            await _semaphore.WaitAsync();
            try
            {
                _products.Add(product);
            }
            finally
            {
                _semaphore.Release();
            }
        }
        public async Task<Product> GetProductAsync(string productName)
        {
            await _semaphore.WaitAsync();
            try
            {
                return _products.First(p => p.Name == productName);
            }
            finally
            {
                _semaphore.Release();
            }
        }
        public async Task<bool> RemoveProductsAsync(Product product)
        {
            await _semaphore.WaitAsync();
            try
            {
                return _products.Remove(product);
            }
            finally
            {
                _semaphore.Release();
            }
        }

    }
}


