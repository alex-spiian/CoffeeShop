using System.Collections.Generic;
using CoffeeShop.Table;
using UnityEngine;
using Wallet;

namespace ExpansionSystem
{
    public class ExpansionSystem : MonoBehaviour
    {
        [SerializeField] private CoffeeShop.CoffeeShop _coffeeShop;
        [SerializeField] private List<Product.Product >_unavailableProducts;
        [SerializeField] private List<Table> _unavailableTables;
        [SerializeField] private WalletService _wallet;
        
        public void AddNewProduct(Product.ProductType productType)
        {
            for (int i = 0; i < _unavailableProducts.Count; i++)
            {
                if (_unavailableProducts[i].Type != productType) continue;

                if (!_wallet.HasEnoughMoney(_unavailableProducts[i].Price))
                {
                    // event not enough money
                    return;
                }
                
                _wallet.SpendMoney(_unavailableProducts[i].Price);
                _coffeeShop.Menu.AddProduct(_unavailableProducts[i]);
                _unavailableProducts.RemoveAt(i);
            }
        }

        public void IncreaseSeatingCapacity()
        {
            var table = _unavailableTables[^1];
            if (!_wallet.HasEnoughMoney(table.Price))
            {
                // event not enough money
                return;
            }
            
            _wallet.SpendMoney(table.Price);
            table.gameObject.SetActive(true);
            _coffeeShop.AddTable(table);
            _unavailableTables.Remove(table);
        }

        public void OpenNewHall()
        {
            
        }
        
    }
}