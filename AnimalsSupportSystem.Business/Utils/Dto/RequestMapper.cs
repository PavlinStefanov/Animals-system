using System;

namespace AnimalsSupportSystem.Business.Utils.Dto
{
    public class RequestMapper
    {
        public DateTimeOffset RequestDate { get; set; }
        public bool IsClosed { get; set; }
        public RecieverMapper Reciever { get; set; }
        public RequestDetailsMapper RequestDetails { get; set; }
    }
}