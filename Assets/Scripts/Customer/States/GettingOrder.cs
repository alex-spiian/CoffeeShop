using System;
using UnityEngine;
using Order = Order.Order;
using Random = UnityEngine.Random;

namespace Customer.States
{
    public class GettingOrder : MonoBehaviour, IState, IInitializable
    {
        private StateMachine _stateMachine;
        private CoffeeShop.CoffeeShop _coffeeShop;
        private ICustomer _customer;
        private global::Order.Order _order;

        public void Initialize(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _customer = GetComponent<ICustomer>();
        }

        public void OnEnter()
        {
            Debug.Log("GettingOrder");
            GetOrder();
        }

        private void GetOrder()
        {
            var availableProducts = _coffeeShop.Menu.AvailableProducts;
            var randomIndex = Random.Range(0, availableProducts.Count);
            _order = new global::Order.Order(availableProducts[randomIndex]);
            _customer.SetOrder(_order);
            Debug.Log("i wanna buy " + availableProducts[randomIndex]);
            
            EnterNegotiatingState();
        }

        private void EnterNegotiatingState()
        {
            _stateMachine.Enter<Negotiating, CoffeeShop.CoffeeShop>(_coffeeShop);
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("CoffeeShop"))
            {
                _coffeeShop = other.GetComponent<CoffeeShop.CoffeeShop>();
            }
        }
    }
}