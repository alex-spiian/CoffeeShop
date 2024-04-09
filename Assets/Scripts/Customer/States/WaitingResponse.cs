using UnityEngine;

namespace Customer.States
{
    public class WaitingResponse : MonoBehaviour, IState, IInitializable
    {
        private StateMachine _stateMachine;
        private bool _isActive;
        public void Initialize(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _isActive = true;
        }

        private void Update()
        {
            if(_isActive) return;
            
            EnterNegotiating();
        }
        
        private void EnterNegotiating()
        {
            _stateMachine.Enter<Negotiating>();
        }
        public void OnEnter()
        {
            _isActive = true;
        }
    }
}