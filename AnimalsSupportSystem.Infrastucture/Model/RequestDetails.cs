
namespace AnimalsSupportSystem.Infrastucture.Model
{
    public class RequestDetails : IAggregateRoot
    {
        public int ID { get; set; }
        public string AnimalType { get; set; }
        public string Gender { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public string Color { get; set; }
        public Request Request { get; set; }
    }
}
