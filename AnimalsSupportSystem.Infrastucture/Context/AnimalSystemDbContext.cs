using AnimalsSupportSystem.Infrastucture.Configuration;
using AnimalsSupportSystem.Infrastucture.Model;
using System.Data.Entity;


namespace AnimalsSupportSystem.Infrastucture.Context
{
    public class AnimalSystemDbContext : DbContext, IAnimalSystemDbContext
    {
        public AnimalSystemDbContext() : base("AnimalsSupportSystem")
        {
            Database.SetInitializer<AnimalSystemDbContext>(null);
        }

        #region Entity Sets
        public IDbSet<Reciever> Recievers { get; set; }
        public IDbSet<Request> Requests { get; set; }
        public IDbSet<RequestDetails> RequestDetails { get; set; }
        public IDbSet<AnimalRegister> AnimalRegisters { get; set; }
        public IDbSet<CleanseCenter> CleanseCenters { get; set; }
        public IDbSet<AdoptionCenter> AdoptionCenters { get; set; }
        public IDbSet<Desease> Deseases { get; set; }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new RecieverConfiguration());
            modelBuilder.Configurations.Add(new RequestConfiguration());
            modelBuilder.Configurations.Add(new RequestDetailsConfiguration());
            modelBuilder.Configurations.Add(new AnimalRegisterConfiguration());
            modelBuilder.Configurations.Add(new CleanseCenterConfiguration());
            modelBuilder.Configurations.Add(new AdoptionCenterConfiguration());
            modelBuilder.Configurations.Add(new DeseaseConfiguration());
        }

        public void Commit()
        {
            base.SaveChanges();
        }
    }
}
