using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsSupportSystem.Infrastucture.Model
{
    public class AnimalRegister : IAggregateRoot
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Type { get; set; }
        public string Gender { get; set; }
        public string Color { get; set; }
        public bool IsCleansed { get; set; }
        public int CleanseCenterID { get; set; }
        public CleanseCenter CleanseCenter { get; set; }
        public int AdoptionCenterID { get; set; }
        public AdoptionCenter AdoptionCenter { get; set; }
        public int DeseaseID { get; set; }
        public Desease Desease { get; set; }
    }
}
