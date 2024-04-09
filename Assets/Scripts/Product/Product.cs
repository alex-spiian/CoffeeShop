using UnityEngine;

namespace Product
{
    public class Product : MonoBehaviour
    { 
        [field:SerializeField]
        public int Price { get; private set; }
        
        [field:SerializeField]
        public ProductType Type { get; private set; }
    }
}