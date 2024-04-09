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
            var order = new global::Order.Order(availableProducts[randomIndex]);
            _customer.SetOrder(order);
            Debug.Log("i wanna buy " + availableProducts[randomIndex]);
            
            EnterMovingToTargetState();
        }

        private void EnterMovingToTargetState()
        {
            var tablePosition = _coffeeShop.GetFreeTable();
            if (tablePosition != null)
            {
                Debug.Log("i am going to " + tablePosition);
                _stateMachine.Enter<Negotiating>();
            }
            else
            {
                // kind of an event that there are no any free tables
            }
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