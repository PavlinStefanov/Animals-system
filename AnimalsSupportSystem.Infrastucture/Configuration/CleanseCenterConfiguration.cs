using AnimalsSupportSystem.Infrastucture.Model;

namespace AnimalsSupportSystem.Infrastucture.Configuration
{
    public class CleanseCenterConfiguration : AggregateRootConfiguration<CleanseCenter>
    {
        public CleanseCenterConfiguration()
        {
            Property(x => x.Name).IsRequired().HasMaxLength(100);
            Property(x => x.Address).IsRequired().HasMaxLength(100);
            HasMany(x => x.Animals).WithOptional().HasForeignKey(x => x.CleanseCenterID);
        }
    }
}
