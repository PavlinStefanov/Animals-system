
using System.Collections;
using System.Collections.Generic;

namespace AnimalsSupportSystem.Infrastucture.Model
{
    public class CleanseCenter : IAggregateRoot
    {
        public CleanseCenter()
        {
            Animals = new List<AnimalRegister>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual ICollection<AnimalRegister> Animals { get; set; }
    }
}
