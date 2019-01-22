using AnimalsSupportSystem.Infrastucture.Model;

namespace AnimalsSupportSystem.Infrastucture.Configuration
{
    public class AdoptionCenterConfiguration : AggregateRootConfiguration<AdoptionCenter>
    {
        public AdoptionCenterConfiguration()
        {
            Property(x => x.Name).IsRequired().HasMaxLength(50);
            Property(x => x.Address).IsRequired().HasMaxLength(100);
            HasMany(x => x.Animals).WithOptional().HasForeignKey(x => x.AdoptionCenterID);
        }
    }
}
