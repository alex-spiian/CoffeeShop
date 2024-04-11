using UnityEngine;

namespace TargetProvider
{
    public class TargetProvider : MonoBehaviour
    {
        [field:SerializeField] public Transform PointToBuy { get; private set; }
        [field:SerializeField] public Transform Exit { get; private set; }
        [field:SerializeField] public CoffeeShop.CoffeeShop CoffeeShop { get; private set; }
    }
}