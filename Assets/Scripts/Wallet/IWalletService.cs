namespace Wallet
{
    public interface IWalletService
    {
        void AddMoney(int money);
        bool SpendMoney(int price);
        bool HasEnoughMoney(int price);
    }
}