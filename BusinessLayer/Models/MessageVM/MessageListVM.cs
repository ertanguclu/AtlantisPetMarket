namespace BusinessLayer.Models.MessageVM
{
    public class MessageListVM
    {

        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string SenderName { get; set; }
        public string ReceiverName { get; set; }
        public string Subject { get; set; }
        public string MessageContent { get; set; }
        public DateTime Date { get; set; }
    }
}
