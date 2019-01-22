namespace AnimalsSupportSystem.Infrastucture.Migrations
{
    using AnimalsSupportSystem.Infrastucture.Context;
    using System.Data.Entity.Migrations;


    internal sealed class Configuration : DbMigrationsConfiguration<AnimalSystemDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AnimalSystemDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
