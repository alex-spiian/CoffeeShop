using System;
using UnityEngine;

namespace Wallet
{
    public class WalletService : MonoBehaviour, IWalletService
    {
        public event Action<int, int> MoneyChanged;
        
        private int _money;

        private void Start()
        {
            AddMoney(100);
        }

        public void AddMoney(int money)
        {
            UpdateMoney(money);
        }

        public bool SpendMoney(int price)
        {
            if (HasEnoughMoney(price))
            {
                UpdateMoney(-price);
                return true;
            }

            return false;
        }

        private void UpdateMoney(int money)
        {
            var previousMoney = _money;
            _money += money;
            
            MoneyChanged?.Invoke(previousMoney, _money);
        }

        public bool HasEnoughMoney(int price)
        {
            return _money >= price;
        }
    }
}