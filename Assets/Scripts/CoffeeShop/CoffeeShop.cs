using System;
using System.Collections.Generic;
using UnityEngine;

namespace CoffeeShop
{
    public class CoffeeShop : MonoBehaviour
    {
        [SerializeField]
        private Table.Table[] _allTables;
        [SerializeField]
        private Product.Product[] _products;
        
        public Menu.Menu Menu { get; private set; }

        private void Awake()
        {
            Menu = new Menu.Menu();
            foreach (var product in _products)
            {
                Menu.AddProduct(product);
            }
        }

        public Vector3? GetFreeTable()
        {
            foreach (var table in _allTables)
            {
                if (table.IsAvailable)
                {
                    return table.GetSeatPosition();
                }
            }

            return null;
        }
    }
}