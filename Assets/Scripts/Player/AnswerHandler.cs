using System;
using NegotiationSystem;
using UnityEngine;
using MessageType = NegotiationSystem.MessageType;

namespace Player
{
    public class AnswerHandler : MonoBehaviour
    {
        public event Action<Answer> AnswerHandled; 
        
        [SerializeField] private AnswerOption[] _answerOptions;
        [SerializeField] private string _defaultMessage;
        
        private Product.ProductType _orderedProductType;
        private int _currentIndex;

        public Answer OnSomeoneCameUp()
        {
            var speakerName = "Owner";
            var messageType = MessageType.Greeting;
            var message = "Hey there! How can I help you?";

            var response = new Answer(speakerName, messageType, message);
            return response;
        }

        public void HandleAnswer(Answer answer)
        {
            if (answer.MessageType == MessageType.Disagreement)
            {
                Debug.Log("customer answered no " + answer.MessageType);
            }
            
            if (answer.MessageType == MessageType.Agreement)
            {
                Debug.Log("customer answered yes" + answer.MessageType);
            }
        }

        public void OnOfferedMore()
        {
            var speakerName = "Owner";
            var messageType = MessageType.Offer;
            var message = _answerOptions[_currentIndex].Option;
            _currentIndex++;
            
            var answer = new Answer(speakerName, messageType, message);
            answer.SetProductType(Product.ProductType.Cappuccino);
            AnswerHandled?.Invoke(answer);
        }
        
        public void OnStoppedOffering()
        {
            var speakerName = "Owner";
            var messageType = MessageType.Goodbye;
            var answer = new Answer(speakerName, messageType, _defaultMessage);
            AnswerHandled?.Invoke(answer);
        }
    }
}