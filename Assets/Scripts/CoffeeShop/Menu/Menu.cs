using System.Collections.Generic;

namespace CoffeeShop.Menu
{
    public class Menu
    {
        public List<Product.Product> AvailableProducts { get; } = new();

        public void AddProduct(Product.Product product)
        {
            AvailableProducts.Add(product);
        }
    }
}