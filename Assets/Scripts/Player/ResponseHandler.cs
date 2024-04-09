using System;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Player
{
    public class ResponseHandler : MonoBehaviour
    {
        public event Action<string, string, bool> AnswerHandled; 
        
        [SerializeField] private AnswerOption[] _answerOptions;
        [SerializeField] private string _defaultMessage;
        private Product.ProductType _orderedProductType;
        private int _currentIndex;

        public void OnCustomerAnsweredGot(Product.ProductType productType)
        {
            _orderedProductType = productType;
        }
        
        public void OnOfferedMore()
        {
            if (_orderedProductType == Product.ProductType.Nothing)
            {
                var randomOption = _answerOptions[_currentIndex];
                AnswerHandled?.Invoke("Owner", randomOption.Option, false);
                _currentIndex++;
                return;
            }
            foreach (var option in _answerOptions)
            {
                if (option.ProductType == _orderedProductType)
                {
                    _currentIndex++;
                    AnswerHandled?.Invoke("Owner", "Sure! " + option.Option, false);
                }
            }
        }
        
        public void OnStoppedOffering()
        {
            AnswerHandled?.Invoke("Owner", _defaultMessage, true);

        }
    }
}