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

        public void BuyNewProduct(Product.ProductType productType)
        {
            expansionSystem.AddNewProduct(productType);
        }

        public void OpenNewHall()
        {
            expansionSystem.OpenNewHall();
        }
    }

}