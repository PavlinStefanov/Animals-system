using AnimalsSupportSystem.Infrastucture.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsSupportSystem.Infrastucture.Configuration
{
    public class RequestDetailsConfiguration : AggregateRootConfiguration<RequestDetails>
    {
        /// <summary>
        /// 
        /// </summary>
        public RequestDetailsConfiguration()
        {
            Property(x => x.AnimalType).IsRequired().HasMaxLength(20);
            Property(x => x.Gender).IsRequired().HasMaxLength(7);
            Property(x => x.MinAge).IsRequired();
            Property(x => x.MaxAge).IsRequired();
            Property(x => x.Color).IsRequired().HasMaxLength(20);
        }
    }
}
