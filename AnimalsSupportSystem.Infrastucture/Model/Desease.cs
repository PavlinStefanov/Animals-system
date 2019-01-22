
using System.Collections.Generic;

namespace AnimalsSupportSystem.Infrastucture.Model
{
    public class Desease : IAggregateRoot
    {
        public Desease()
        {
            Animals = new List<AnimalRegister>();
        }
        public int ID { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public virtual ICollection<AnimalRegister> Animals { get; set; }
    }
}
