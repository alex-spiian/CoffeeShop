using Order;
using UnityEngine;

namespace Customer
{
    public class CustomerSpawner : MonoBehaviour
    {
        [SerializeField] private TargetProvider.TargetProvider _targetProvider;
        [SerializeField] private Customer _customerPrefab;

        private void Awake()
        { 
            Spawn();
        }

        private void Spawn()
        {
            var customer =  Instantiate(_customerPrefab, transform.position, Quaternion.identity);
            customer.Initialize(_targetProvider);
        }
    }
}