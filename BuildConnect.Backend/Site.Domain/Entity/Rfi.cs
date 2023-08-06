using Site.Domain.Common;

namespace Site.Domain.Entity
{
    public class RFIModel: BaseModel
    {
        public string Content { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public Guid Sender { get; set; }
        public Guid Reciever { get; set; }
        public Guid RFIID { get; set; }
        public Guid Attachement { get; set; }
    }
}
