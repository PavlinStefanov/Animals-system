using System;

namespace AnimalsSupportSystem.Infrastucture.Model
{
    public class Request : IAggregateRoot
    {
        public int ID { get; set; }
        public DateTimeOffset RequestDate { get; set; }
        public bool IsClosed { get; set; }
        public int RecieverID { get; set; }
        public Reciever Reciever { get; set; }
        public RequestDetails RequestDetails { get; set; }
    }
}
