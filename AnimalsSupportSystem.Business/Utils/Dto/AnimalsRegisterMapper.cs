
namespace AnimalsSupportSystem.Business.Utils.Dto
{
    public class AnimalsRegisterMapper
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Type { get; set; }
        public string Gender { get; set; }
        public string Color { get; set; }
        public bool IsCleansed { get; set; }
        public int DeseaseID { get; set; }
        public int AdoptionCenterID { get; set; }
    }
}