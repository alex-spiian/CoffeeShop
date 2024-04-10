
namespace NegotiationSystem
{
    public class Answer
    {
        public string SpeakerName { get; }
        public MessageType MessageType { get; }
        public string Message { get; }
        public Product.ProductType ProductType { get; private set; }

        public Answer(string speakerName, MessageType messageType, string message)
        {
            SpeakerName = speakerName;
            MessageType = messageType;
            Message = message;
        }

        public void SetProductType(Product.ProductType type)
        {
            ProductType = type;
        }
    }
}