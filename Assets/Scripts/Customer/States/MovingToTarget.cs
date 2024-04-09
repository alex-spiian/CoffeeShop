using System;
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
            movableCustomer.Move(position, OnCameToTarget);
        }

        private void OnCameToTarget()
        {
            Debug.Log("came to target");
            _stateMachine.Enter<GettingOrder>();
        }
    }
}