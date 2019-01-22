using AnimalsSupportSystem.Infrastucture.Model;

namespace AnimalsSupportSystem.Infrastucture.Configuration
{
    public class AnimalRegisterConfiguration : AggregateRootConfiguration<AnimalRegister>
    {
        public AnimalRegisterConfiguration()
        {
            Property(x => x.Name).IsOptional().HasMaxLength(50);
            Property(x => x.Age).IsOptional();
            Property(x => x.Type).IsRequired().HasMaxLength(50);
            Property(x => x.Gender).IsRequired().HasMaxLength(7);
            Property(x => x.Color).IsRequired().HasMaxLength(30);
            Property(x => x.IsCleansed).IsRequired();
            Property(x => x.CleanseCenterID).IsOptional();
            Property(x => x.AdoptionCenterID).IsOptional();
            Property(x => x.DeseaseID).IsRequired();
        }
    }
}
