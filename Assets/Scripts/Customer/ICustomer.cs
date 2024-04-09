using Order;

namespace Customer
{
    public interface ICustomer
    {
        public Order.Order Order { get; }
        public string Name { get; }
        public TargetProvider.TargetProvider TargetProvider { get; }

        public void SetOrder(Order.Order order);
    }
}