using System.Collections.Generic;
using UnityEngine;
using Wallet;

namespace CoffeeShop
{
    public class CoffeeShopInventory : MonoBehaviour
    {
        [SerializeField] private WalletService _wallet;
        private readonly Dictionary<Product.Product, int> _boughtProducts = new();

        public void AddProduct(Product.Product product)
        {
            Debug.Log(product + " was bought");
            if (_boughtProducts.ContainsKey(product))
            {
                _boughtProducts[product]++;
            }
            else
            {
                _boughtProducts.Add(product, 1);
            }
        }

        public void ChargeForProducts()
        {
            var money = 0;
            foreach (var keyValue in _boughtProducts)
            {
                money += keyValue.Key.Price;
            }
            
            _wallet.AddMoney(money);
            _boughtProducts.Clear();
        }
    }
}