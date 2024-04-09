using System;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Customer.States
{
    public class Negotiating : MonoBehaviour, IState, IInitializable
    {
        private event Action<string, string, Product.ProductType> Responsing;
        [SerializeField] private string[] _noOptions;

        private NegotiationSystem.NegotiationSystem _negotiationSystem;
        private ICustomer _customer;
        private StateMachine _stateMachine;
        private int _offerCounter;

        public void Initialize(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _customer = GetComponent<ICustomer>();

        }
        
        public void OnEnter()
        {
            GreetSomeone();
            _negotiationSystem.PlayerAnswered += OnPlayerAnswered;
        }

        private void GreetSomeone()
        {
            var order = _customer.Order;
            var message = "Hello! Can I have one " + order.Product.Type;
            Responsing?.Invoke(_customer.Name, message, order.Product.Type);
            EnterWaitingResponse();
        }

        private void OnPlayerAnswered(bool wasConversationEnded)
        {
            _offerCounter++;
            SendResponse(wasConversationEnded);
        }
        
        private async Task SendResponse(bool wasConversationEnded)
        {
            await Task.Delay(2000);
            if (_offerCounter > 3)
            {
                Responsing?.Invoke(_customer.Name, "Oh my god, drink your coffee yourself dude! better i'll go to kfc", Product.ProductType.Nothing);
                EnterMovingToTarget();
                return;
            }
            if (!wasConversationEnded)
            {
                Responsing?.Invoke(_customer.Name, _noOptions[Random.Range(0, _noOptions.Length)], Product.ProductType.Nothing);
            }
            else
            {
                Responsing?.Invoke(_customer.Name, "Thank you so much!", Product.ProductType.Nothing);
            }
        }
        
        private void EnterWaitingResponse()
        {
            _stateMachine.Enter<WaitingResponse>();
        }
        
        private void EnterMovingToTarget()
        {
            _stateMachine.Enter<MovingToTarget, Vector3>(new Vector3(0.529999971f,-0.200000003f,11.6199999f));
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("NegotiationSystem")) return;
            
            _negotiationSystem = other.GetComponent<NegotiationSystem.NegotiationSystem>();
            Responsing += _negotiationSystem.OnResponse;
        }

        private void OnDestroy()
        {
            Responsing -= _negotiationSystem.OnResponse;
        }
    }
}