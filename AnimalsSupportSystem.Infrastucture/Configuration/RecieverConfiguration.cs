using AnimalsSupportSystem.Infrastucture.Model;

namespace AnimalsSupportSystem.Infrastucture.Configuration
{
    public class RecieverConfiguration : AggregateRootConfiguration<Reciever>
    {
        /// <summary>
        /// 
        /// </summary>
        public RecieverConfiguration()
        {
            Property(x => x.FirstName).IsRequired().HasMaxLength(25);
            Property(x => x.LastName).IsRequired().HasMaxLength(25);
            Property(x => x.Age).IsRequired();
            Property(x => x.Address).IsRequired().HasMaxLength(150);
            HasMany(x => x.Requests).WithRequired().HasForeignKey(x => x.RecieverID);
        }
    }
}
