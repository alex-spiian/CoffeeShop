using Order;
using UnityEngine;

namespace Customer
{
    public class CustomerFactory
    {
        private TargetProvider.TargetProvider _targetProvider;

        public CustomerFactory(TargetProvider.TargetProvider targetProvider)
        {
            _targetProvider = targetProvider;
        }

        public Customer Create(Customer prefab, Transform root)
        {
            var customer =  Object.Instantiate(prefab, root.position, Quaternion.identity);
            customer.Initialize(_targetProvider);
            return customer;
        }
    }
}