using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NegotiationSystem
{
    public class NegotiationView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _nameLabel;
        [SerializeField] private TextMeshProUGUI _dialogLabel;

        [SerializeField] private Button[] _buttons;

        public void OnSomeoneAnswered(Answer answer)
        {
            _nameLabel.text = answer.SpeakerName;
            _dialogLabel.text = answer.Message;

            if (answer.SpeakerName == "Owner")
            {
                OnCustomerSpeech();
            }

            else if (answer.MessageType != MessageType.Goodbye)
            {
                OnPlayerSpeech();

            }
        }

        private void OnPlayerSpeech()
        {
            foreach (var button in _buttons)
            {
                button.gameObject.SetActive(true);
            }
        }
        
        private void OnCustomerSpeech()
        {
            foreach (var button in _buttons)
            {
                button.gameObject.SetActive(false);
            }
        }
    }
}