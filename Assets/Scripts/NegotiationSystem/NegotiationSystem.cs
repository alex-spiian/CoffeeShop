using System;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NegotiationSystem
{
    public class NegotiationSystem : MonoBehaviour
    {
        public event Action<Product.ProductType> CustomerAnswered; 
        public event Action<bool> PlayerAnswered; 
        
        [SerializeField] private TextMeshProUGUI _nameLabel;
        [SerializeField] private TextMeshProUGUI _dialogLabel;
        [SerializeField] private ResponseHandler _responseHandler;

        [SerializeField] private Button[] _buttons;
        private void Awake()
        {
            CustomerAnswered += _responseHandler.OnCustomerAnsweredGot;
            _responseHandler.AnswerHandled += OnResponse;
        }

        public void OnResponse(string name, string message, Product.ProductType productType)
        {
            _nameLabel.text = name;
            _dialogLabel.text = message;
            CustomerAnswered?.Invoke(productType);
            
            foreach (var button in _buttons)
            {
                button.gameObject.SetActive(true);
            }
        }
        
        private void OnResponse(string name, string message, bool wasConversationStopped)
        {
            _nameLabel.text = name;
            _dialogLabel.text = message;
            
            PlayerAnswered?.Invoke(wasConversationStopped);
            foreach (var button in _buttons)
            {
                button.gameObject.SetActive(false);
            }
        }

        private void OnDestroy()
        {
            _responseHandler.AnswerHandled -= OnResponse;

        }
    }
}