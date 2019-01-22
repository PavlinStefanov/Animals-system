
namespace AnimalsSupportSystem.Infrastucture.Context
{
    public interface IAnimalSystemDbContextFactory<out TContext> where TContext : IAnimalSystemDbContext
    {
        TContext Create();
    }
}
