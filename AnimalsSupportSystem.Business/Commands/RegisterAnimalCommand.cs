using AnimalsSupportSystem.Business.Domain;
using AnimalsSupportSystem.Business.Utils.Dto;
using AnimalsSupportSystem.Business.Utils;
using AnimalsSupportSystem.Infrastucture.Context;
using log4net;
using System;

namespace AnimalsSupportSystem.Business.Commands
{
    public class RegisterAnimalCommand : IMedicalCommand
    {
        private readonly IAnimalSystemDbContextFactory<IAnimalSystemDbContext> _dbContextFactory;
        private readonly AnimalsRegisterMapper _animal;
        private static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public RegisterAnimalCommand(IAnimalSystemDbContextFactory<IAnimalSystemDbContext> dbContextFactory, AnimalsRegisterMapper animal)
        {
            _dbContextFactory = dbContextFactory;
            _animal = animal;
            IsCompleted = false;
        }

        public bool IsCompleted { get; set; }

        public void Execute()
        {
            try
            {
                using (var dbContext = _dbContextFactory.Create())
                {
                    dbContext.AnimalRegisters.Add(_animal.ToEntity());
                    dbContext.Commit();
                }

                IsCompleted = true;
                _log.Info($"Created new Animal center: '{_animal.Name}' in the database.");
            }
            catch (Exception ex)
            {
                _log.Error($"Unable to create new Animal center for '{_animal.Name}' in the database.", ex);
                throw new Exception($"Unable to create new animal for '{_animal.Name}'.", ex);
            }
        }
    }
}
