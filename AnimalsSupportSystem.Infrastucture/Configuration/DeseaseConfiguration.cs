using AnimalsSupportSystem.Infrastucture.Model;

namespace AnimalsSupportSystem.Infrastucture.Configuration
{
    public class DeseaseConfiguration : AggregateRootConfiguration<Desease>
    {
        public DeseaseConfiguration()
        {
            Property(x => x.Type).IsRequired().HasMaxLength(100);
            Property(x => x.Description).IsRequired();
            HasMany(x => x.Animals).WithRequired().HasForeignKey(x => x.DeseaseID);
        }
    }
}
