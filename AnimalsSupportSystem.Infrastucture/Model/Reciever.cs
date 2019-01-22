using System.Collections.Generic;

namespace AnimalsSupportSystem.Infrastucture.Model
{
    public class Reciever : IAggregateRoot
    {
        public Reciever()
        {
            Requests = new List<Request>();
        }
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
    }
}
