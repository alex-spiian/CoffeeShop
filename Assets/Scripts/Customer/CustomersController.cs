using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Serialization;

namespace Customer
{
    public class CustomersController : MonoBehaviour
    {
        [SerializeField] private TargetProvider.TargetProvider _targetProvider;
        [SerializeField] private Customer _customerPrefab;
        
        [SerializeField] private int _maxCustomersCountInMart;
        [SerializeField] private int _delay;
        
        private CustomerFactory _customersFactory;
        private int _currentCustomersCountInMart;

        private void Awake()
        {
            _customersFactory = new CustomerFactory(_targetProvider);
            SpawnCustomers();
        }

        public void Initialize()
        {
            SpawnCustomers();
        }
        
        public void IncreaseMaxCustomersCount(int value)
        {
            _maxCustomersCountInMart += value;
        }
        
        private void OnCustomerLeft()
        {
            _currentCustomersCountInMart--;
            if (_currentCustomersCountInMart == 0)
            { 
                SpawnCustomers();
            }
        }

        private async Task SpawnCustomers()
        {
            while (_currentCustomersCountInMart < _maxCustomersCountInMart)
            {
                _customersFactory.Create(_customerPrefab, transform);
                _currentCustomersCountInMart++;
                await Task.Delay(_delay * 1000);
            }
        }
        
    }
}