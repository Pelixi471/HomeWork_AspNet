using HomeWork_AspNet;
using System.Collections.Concurrent;

namespace HomeWork_AspNet
{
    //ДЗ3-потокобезопасная коллекция
    public class CatalogBag
    {
        private readonly ConcurrentBag<Product> _productsBag = new()
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
        public Product[] GetProductsBag()
        {
            return _productsBag.ToArray();
        }

        public Product GetProductBag(string productName)
        {
            return _productsBag.First(p => p.Name == productName);
        }

        public void AddProductsBag(Product product)
        {
            _productsBag.Add(product);
        }
        public Product RemoveProductBag(Product product)
        {
            _productsBag.TryTake(out product);
            return product;
        }

    }
}
