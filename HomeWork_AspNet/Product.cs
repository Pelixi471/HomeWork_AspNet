using Microsoft.AspNetCore.Mvc;

namespace HomeWork_AspNet
{
    public class Product
    {
        public Product(string name, decimal price)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException($"'{nameof(name)}' не может быть NULL.", nameof(name));
            }
            if (price < 0)
            {
                throw new ArgumentNullException(nameof(price));
            }
            Name = name;
            Price = price;
        }
        public string Name { get; set; }
        public decimal Price { get; set; }

    }
}
