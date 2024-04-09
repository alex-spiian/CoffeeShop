using System.Collections.Generic;
using Product;

namespace Order
{
    public class Order
    {
        public Product.Product Product{ get; }

        public Order(Product.Product product)
        {
            Product = product;
        }
        
    }
}