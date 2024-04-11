using System;
using System.Threading.Tasks;
using Customer;
using Customer.States;
using InteractablePoint;
using Player;
using UnityEngine;

namespace NegotiationSystem
{
    public class NegotiationSystem : MonoBehaviour
    {

        private event Action<Answer> SomeoneAnswered;
        private event Action<Answer> SoldSuccessfully;

        [SerializeField] private NegotiationView _negotiationView;
        [SerializeField] private AnswerHandler _answerHandler;
        [SerializeField] private CoffeeShop.CoffeeShop _coffeeShop;
        private Negotiating _customer;

        private void Awake()
        {
            SomeoneAnswered += _negotiationView.OnSomeoneAnswered;
            _answerHandler.AnswerHandled += OnSomeoneAnswered;
        }

        public async Task StartConversation(Negotiating customer)
        {
            _customer = customer;
            _customer.AnswerHandled += OnSomeoneAnswered;
            
            var playerAnswer = _answerHandler.OnSomeoneCameUp();
            SomeoneAnswered?.Invoke(playerAnswer);
            
            _customer.AnswerQuestion(playerAnswer);
        }

        private void OnSomeoneAnswered(Answer answer)
        {
            KeepNegotiating(answer);
        }
        private void KeepNegotiating(Answer question)
        {
            if (question.MessageType == MessageType.Goodbye && question.SpeakerName != "Owner")
            {
                _coffeeShop.Bar.Queue.OnCustomerLeft(_customer.GetComponent<ICustomerInQueue>());
            }
            
            if (question.SpeakerName == "Owner")
            {
                _customer.AnswerQuestion(question);
            }
            
            else
            {
                _answerHandler.HandleAnswer(question);
            }
            
            SomeoneAnswered?.Invoke(question);
        }

        private void OnDestroy()
        {
            SomeoneAnswered -= _negotiationView.OnSomeoneAnswered;
            _answerHandler.AnswerHandled -= OnSomeoneAnswered;

        }
    }
}