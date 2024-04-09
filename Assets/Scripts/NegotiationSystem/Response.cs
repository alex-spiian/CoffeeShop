using Customer;

namespace NegotiationSystem
{
    public class Response
    {
        public CustomerType CustomerType { get; }
        public Order.Order Order { get; }

        public Response(CustomerType customerType, Order.Order order)
        {
            CustomerType = customerType;
            Order = order;
        }
    }
}