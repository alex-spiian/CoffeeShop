using System;
using System.Threading.Tasks;
using NegotiationSystem;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Customer.States
{
    public class Negotiating : MonoBehaviour, IPayLoadedState<Order.Order>
    {
        public event Action<Answer> AnswerHandled; 

        [SerializeField] private string[] _noOptions;
        [SerializeField] private AnswerOption[] _answerOptions;

        private NegotiationSystem.NegotiationSystem _negotiationSystem;
        private StateMachine _stateMachine;
        private int _offerCounter;
        private Order.Order _order;

        public void Initialize(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        
        public void OnEnter(Order.Order order)
        {
            _order = order;
            _negotiationSystem.StartConversation(this);
        }

        public async Task AnswerQuestion(Answer question)
        {
            await Task.Delay(3000);

            var answer = question;
            
            if (_offerCounter >= 3)
            {
                answer.SetName("Helen");
                answer.SetMessageType(MessageType.Goodbye);
                answer.SetMessage("Fuck you");
                answer.SetProduct(null);
                AnswerHandled?.Invoke(answer);
                
                EnterMovingToTarget();
                return;
            }
            if (question.MessageType == MessageType.Greeting)
            {
                answer.SetName("Helen");
                answer.SetMessageType(MessageType.Order);
                answer.SetMessage("Hello, can I Have one " + _order.Product.Type + "?");
                answer.SetProduct(_order.Product);
                Debug.Log(answer.Product);
                AnswerHandled?.Invoke(answer);
                return;
            }

            if (question.MessageType == MessageType.Offer)
            {
                _offerCounter++;

                var randomAnswerOption = _answerOptions[Random.Range(0, _answerOptions.Length)];
                answer.SetProduct(randomAnswerOption.Type == MessageType.Agreement ? question.Product : null);
                
                answer.SetName("Helen");
                answer.SetMessageType(randomAnswerOption.Type);
                answer.SetMessage(randomAnswerOption.Option);
                AnswerHandled?.Invoke(answer);
                return;
            }

            if (question.MessageType == MessageType.Goodbye)
            {
                answer.SetName("Helen");
                answer.SetMessageType(MessageType.Goodbye);
                answer.SetMessage("Thank you. Buy");
                answer.SetProduct(null);

                EnterMovingToTarget();
                AnswerHandled?.Invoke(answer);
            }

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