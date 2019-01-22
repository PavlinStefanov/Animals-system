using AnimalsSupportSystem.Infrastucture.Model;

namespace AnimalsSupportSystem.Infrastucture.Configuration
{
    public class RequestConfiguration : AggregateRootConfiguration<Request>
    {
        /// <summary>
        /// 
        /// </summary>
        public RequestConfiguration()
        {
            Property(x => x.RequestDate).IsRequired();
            Property(x => x.IsClosed).IsRequired();
            Property(x => x.RecieverID).IsRequired();
            HasRequired(x => x.RequestDetails).WithRequiredPrincipal(x => x.Request);
        }
    }
}
