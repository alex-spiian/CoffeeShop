using System;
using UnityEngine;

namespace ExpansionSystem
{
    public class UpgradeMenu : MonoBehaviour
    {
        public ExpansionSystem expansionSystem;

        public void BuyNewTable()
        {
            expansionSystem.IncreaseSeatingCapacity();
        }

        public void BuyNewProduct(string productType)
        {
            Enum.TryParse(productType, out Product.ProductType type);

            expansionSystem.AddNewProduct(type);
        }

        public void OpenNewHall()
        {
            expansionSystem.OpenNewHall();
        }
    }

}