
namespace NegotiationSystem
{
    public class Answer
    {
        public string SpeakerName { get; private set; }
        public MessageType MessageType { get; private set; }
        public string Message { get; private set; }
        public Product.Product Product { get; private set; }

        public Answer(string speakerName, MessageType messageType, string message)
        {
            SpeakerName = speakerName;
            MessageType = messageType;
            Message = message;
        }

        public void SetProduct(Product.Product product)
        {
            Product = product;
        }

        public void SetName(string name)
        {
            SpeakerName = name;
        }
        
        public void SetMessage(string message)
        {
            Message = message;
        }
        
        public void SetMessageType(MessageType messageType)
        {
            MessageType = messageType;
        }
    }
}