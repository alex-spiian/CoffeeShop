using System;
using InteractablePoint;
using UnityEngine;

namespace Customer.States
{
    public class MovingToTarget : MonoBehaviour, IPayLoadedState<Vector3>
    {
        private StateMachine _stateMachine;
        private ICustomer _customer;
        private TargetProvider.TargetProvider _targetProvider;

        private void Awake()
        {
            _customer = GetComponent<ICustomer>();
        }

        public void Initialize(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _targetProvider = _customer.TargetProvider;
        }

        public void OnEnter(Vector3 position)
        {
            Debug.Log("MovingToTarget");
            Move(position);
        }

        private void Move(Vector3 position)
        {
            var movableCustomer = (IMovable)_customer;
            movableCustomer.Move(position);
        }

        private void EnterGettingOrder()
        {
            Debug.Log("EnterGettingOrder");
            _stateMachine.Enter<GettingOrder>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IInteractablePoint point))
            {
                switch (point.Type)
                {
                    case InteractableType.CoffeeShop:
                        var coffeeShop = (CoffeeShop.CoffeeShop)point;
                        var queue = coffeeShop.Bar.Queue;
                        Move(queue.GetFreePosition((ICustomerInQueue)_customer));
                        break;
                    case InteractableType.Bar:
                        EnterGettingOrder();
                        break;
                }
            }
        }
    }
}