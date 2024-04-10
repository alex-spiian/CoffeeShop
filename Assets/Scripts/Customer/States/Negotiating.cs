using System;
using System.Threading.Tasks;
using NegotiationSystem;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Customer.States
{
    public class Negotiating : MonoBehaviour, IState, IInitializable
    {
        public event Action<Answer> AnswerHandled; 

        [SerializeField] private string[] _noOptions;
        [SerializeField] private AnswerOption[] _answerOptions;

        private NegotiationSystem.NegotiationSystem _negotiationSystem;
        private StateMachine _stateMachine;
        private int _offerCounter;

        public void Initialize(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;

        }
        
        public void OnEnter()
        {
            _negotiationSystem.StartConversation(this);
        }

        public async Task AnswerQuestion(Answer question)
        {
            await Task.Delay(3000);

            if (_offerCounter >= 3)
            {
                var answer = new Answer("Helen", MessageType.Goodbye, "Fuck you");
                AnswerHandled?.Invoke(answer);
                EnterMovingToTarget();
                return;
            }
            if (question.MessageType == MessageType.Greeting)
            {
                var answer = new Answer("Helen", MessageType.Order, "Hello, can I Have an espresso?");
                AnswerHandled?.Invoke(answer);
                return;
            }

            if (question.MessageType == MessageType.Offer)
            {
                _offerCounter++;

                var randomAnswerOption = _answerOptions[Random.Range(0, _answerOptions.Length)];
                
                var answer = new Answer("Helen", randomAnswerOption.Type, randomAnswerOption.Option);
                answer.SetProductType(Product.ProductType.Cappuccino);
                AnswerHandled?.Invoke(answer);
                return;
            }

            if (question.MessageType == MessageType.Goodbye)
            {
                var answer = new Answer("Helen", MessageType.Goodbye, "Thank you. Buy");
                EnterMovingToTarget();
                AnswerHandled?.Invoke(answer);
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
        }
    }
}