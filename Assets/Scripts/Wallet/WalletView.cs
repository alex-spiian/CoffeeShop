using System;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Wallet
{
    public class WalletView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _money;
        [SerializeField]
        private float _durationMoneyChange;
        [SerializeField]
        private WalletService _walletService;

        private void Awake()
        {
            _walletService.MoneyChanged += SetMoney;
        }
        private void UpdateView(int amountMoney)
        {
            Debug.Log(amountMoney);
            _money.text = amountMoney.ToString();
        }
        
        private void SetMoney(int previousAmount, int currentAmount)
        {
            StartMoneyChangeAnimation(previousAmount, currentAmount);
        }

        private async Task StartMoneyChangeAnimation(int previousAmountMoney, int currentAmountMoney)
        {
            var currentTime = 0f;
            while (currentTime < _durationMoneyChange)
            {
                var progress = currentTime / _durationMoneyChange;
                var amountMoney = (int)Mathf.Lerp(previousAmountMoney, currentAmountMoney, progress);
                currentTime += Time.deltaTime;
                UpdateView(amountMoney);
                await Task.Delay(1);
            }

            UpdateView(currentAmountMoney);
        }
    }
}