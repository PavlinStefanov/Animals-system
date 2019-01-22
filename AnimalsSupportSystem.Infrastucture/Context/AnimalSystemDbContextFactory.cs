
namespace AnimalsSupportSystem.Infrastucture.Context
{
    public class AnimalSystemDbContextFactory : IAnimalSystemDbContextFactory<IAnimalSystemDbContext>
    {
        public IAnimalSystemDbContext Create()
        {
            return new AnimalSystemDbContext();
        }
    }
}
