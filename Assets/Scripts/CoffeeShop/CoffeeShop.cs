using System.Collections.Generic;
using InteractablePoint;
using UnityEngine;

namespace CoffeeShop
{
    public class CoffeeShop : MonoBehaviour, IInteractablePoint
    {
        [SerializeField]
        private List<Table.Table> _allTables;
        [SerializeField]
        private Product.Product[] _products;

        [field:SerializeField] public Bar.Bar Bar { get; private set; }
        [field:SerializeField] public InteractableType Type { get; private set; }
        public Vector3 Position => transform.position;
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

        public void AddTable(Table.Table table)
        {
            _allTables.Add(table);
        }

        public int GetProductPrice(Product.ProductType type)
        {
            return 0;
        }
    }
}