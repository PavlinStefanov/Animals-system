using AnimalsSupportSystem.Business.Domain;
using AnimalsSupportSystem.Business.Utils.Dto;
using AnimalsSupportSystem.Business.Utils;
using AnimalsSupportSystem.Infrastucture.Context;
using log4net;
using System;

namespace AnimalsSupportSystem.Business.Commands
{
    public class CreateAdoptionCenterCommand : IMedicalCommand
    {
        private readonly IAnimalSystemDbContextFactory<IAnimalSystemDbContext> _dbContextFactory;
        private readonly AdoptionCenterMapper _adoption;
        private static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public CreateAdoptionCenterCommand(IAnimalSystemDbContextFactory<IAnimalSystemDbContext> dbContextFactory, AdoptionCenterMapper adoption)
        {
            _dbContextFactory = dbContextFactory;
            _adoption = adoption;
            IsCompleted = false;
        }
        public bool IsCompleted { get; set; }

        public void Execute()
        {
            try
            {
                using (var dbContext = _dbContextFactory.Create())
                {
                    dbContext.AdoptionCenters.Add(_adoption.ToEntity());
                    dbContext.Commit();
                }

                IsCompleted = true;
                _log.Info($"Created new Adoption center: '{_adoption.Name}' in the database.");
            }
            catch (Exception ex)
            {
                _log.Error($"Unable to create new addoption center for '{_adoption.Name}' in the database.", ex);
                throw new Exception($"Unable to create new addoption center for '{_adoption.Name}'.", ex);
            }
        }
    }
}
