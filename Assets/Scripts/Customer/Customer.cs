using System;
using Customer.States;
using Customermovement;
using Order;
using Unity.VisualScripting;
using UnityEngine;

namespace Customer
{
    public class Customer : MonoBehaviour, ICustomer, IMovable, ICustomerInQueue
    {
        [field:SerializeField] public string Name { get; private set; }
        [SerializeField] private CustomerType _type;
        [SerializeField] private MovementController _movementController;
        public Vector3 PositionInLine { get; private set; }

        public Order.Order Order { get; private set; }
        public TargetProvider.TargetProvider TargetProvider { get; private set; }
       

        private void Start()
        {
            var stateMachine = new StateMachine
            (
                GetComponent<GettingOrder>(),
                GetComponent<MovingToTarget>(),
                GetComponent<WaitingResponse>(),
                GetComponent<Negotiating>()
            );
            
            stateMachine.Initialize();
            stateMachine.Enter<MovingToTarget, Vector3>(TargetProvider.CoffeeShop.Position);
        }

        public void Initialize(TargetProvider.TargetProvider targetProvider)
        {
            TargetProvider = targetProvider;
        }

        public void SetOrder(Order.Order order)
        {
            Order = order;
        }

        public void SetPositionInLine(Vector3 position)
        {
            PositionInLine = position;
        }


        public void Move(Vector3 targetPosition, Action CameToTarget)
        {
            _movementController.Move(targetPosition, CameToTarget);
        }
        
        public void Move(Vector3 targetPosition)
        {
            _movementController.Move(targetPosition);
        }
    }
}