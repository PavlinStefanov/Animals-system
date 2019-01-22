using AnimalsSupportSystem.Infrastucture.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsSupportSystem.Infrastucture.Configuration
{
    public class AggregateRootConfiguration<TEntity> : EntityTypeConfiguration<TEntity> where TEntity : class, IAggregateRoot
    {
        public AggregateRootConfiguration()
        {
            HasKey(x => x.ID);
        }
    }
}
